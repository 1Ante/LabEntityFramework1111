using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab1EntityFramework.Models
{
    public class Employee
    {   
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //Konstruktor för att fylla i data i tabellen genom koden
        public Employee (string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        
        public ICollection<Vacation> Vacations { get; set; }

        

    }
}
