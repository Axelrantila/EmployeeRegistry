namespace EmployeesRegister.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.EmployeesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLayer.EmployeesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Employees.AddOrUpdate(e => new { e.FirstName, e.LastName, e.Position, e.Department, e.Company},
            new Employee { FirstName = "Axel", LastName = "Räntilä", Salary = 50000, Position = "Supreme Programmer", Department = "Engineering", Company = "Self-employed"},
            new Employee { FirstName = "Lorem", LastName = "Ipsum", Salary = 1234, Position = "Writer", Department = "Markerting", Company="Lorem Ipsum"},
            new Employee { FirstName = "Reno", LastName = "Jackson", Salary = 30, Position = "Explorer", Department = "Sport", Company = "The League of Explorers"},
            new Employee { FirstName = "Lily", LastName = "Shen", Salary = 55555, Position = "Chief Engineer", Department = "Engineering", Company = "XCOM"},
            new Employee { FirstName = "Richard", LastName = "Tygan", Salary = 55555, Position = "Chief Science Officer", Department = "Research", Company = "XCOM" },
            new Employee { FirstName = "Martin", LastName = "Johansson", Salary = 24000, Position = "Scientist", Department = "Research", Company = "XCOM"},
            new Employee { FirstName = "Martin", LastName = "Anward", Salary = 25255, Position = "AI Lead", Department = "Game Development", Company = "Paradox"},
            new Employee { FirstName = "Arbritary", LastName = "Name", Salary = 123456, Position = "Arbritary Position", Department = "Arbritary Department", Company = "Arbritary Company"},
            new Employee { FirstName = "Jonas", LastName = "Robot", Salary = 30000, Position = "Content Producer", Department = "Marketing" , Company = "CasinoRobot"},
            new Employee { FirstName = "Maya", LastName = "Prince", Salary = 30001, Position = "Actor", Department = "Marketing", Company = "Advertising AB"}
            );
        }
    }
}
