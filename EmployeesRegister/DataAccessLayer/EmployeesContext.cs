using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeesRegister.DataAccessLayer
{
    public class EmployeesContext:
        DbContext
    {
        public EmployeesContext()
            :base("DefaultConnection")
        {

        }

        public DbSet<Models.Employee> Employees { get; set; }
    }
}