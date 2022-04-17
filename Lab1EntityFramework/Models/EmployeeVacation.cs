using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1EntityFramework.Models
{
    class EmployeeVacation : DbContext
    {
     
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Vacation> Vacations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-BRKQTHE\SQLEXPRESS;Initial Catalog=EmployeeVacation;Integrated Security = True;");
        }
    }
}
