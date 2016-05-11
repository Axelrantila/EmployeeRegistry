using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeesRegister.DataAccessLayer;
using EmployeesRegister.Models;

namespace EmployeesRegister.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeesContext db = new EmployeesContext();

        // GET: Employees
        //public ActionResult Index()
        //{
        //    return View(db.Employees.ToList().OrderBy(e => e.LastName));
        //}

        public ActionResult Index(string searchFirstName, string searchLastName, string searchSalary, string searchPosition, string searchDepartment, string searchBosses, string searchMoreThanAverage)
        {
            int salary = -1;

            try
            {
                salary = int.Parse(searchSalary);
            }
            catch (Exception) { }

            float sumSalary = 0;
            foreach (var e in db.Employees)
            {
                sumSalary += e.Salary;
            }

            //int average = (int)(sumSalary / db.Employees.Count());

            int average = (int)db.Employees.Average(r => r.Salary);

            return View(db.Employees
                .Where(r => string.IsNullOrEmpty(searchFirstName) || r.FirstName.ToLower().Contains(searchFirstName.ToLower()))
                .Where(r => string.IsNullOrEmpty(searchLastName) || r.LastName.ToLower().Contains(searchLastName.ToLower()))
                .Where(r => salary == -1 || r.Salary >= salary)
                .Where(r => string.IsNullOrEmpty(searchPosition) || r.Position.ToLower().Contains(searchPosition.ToLower()))
                .Where(r => string.IsNullOrEmpty(searchDepartment) || r.Department.ToLower().Contains(searchDepartment.ToLower()))
                .Where(r => string.IsNullOrEmpty(searchBosses) ||
                    (r.Position.ToLower().Contains("Chief") || r.Position.ToLower().Contains("Lead") || r.Position.ToLower().Contains("Boss"))
                    || (r.FirstName == "Axel" && r.LastName == "Räntilä"))
                .Where(r => string.IsNullOrEmpty(searchMoreThanAverage) || r.Salary > average)
                .OrderBy(r => r.LastName)
                .ToList());

        }

        public ActionResult Marketing()
        {
            var model = db.Employees.Where(e => e.Department == "Marketing").OrderBy(e => e.LastName).ToList();
            return View(model);
        }

        public ActionResult Search()
        {
            return View();
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Salary,Position,Department")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Salary,Position,Department,Company")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
