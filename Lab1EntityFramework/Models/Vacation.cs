using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab1EntityFramework.Models
{
    public class Vacation
    {   
        [Key]
        public int VacationId { get; set; }

        [Required]
        public string VacationType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime RegDateTime { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        //Konstruktor för att fylla i data i tabellen genom koden
        public Vacation(string vacationType, DateTime startDate, DateTime endDate, DateTime regDateTime, int employeeId)
        {
            VacationType = vacationType;
            StartDate = startDate;
            EndDate = endDate;
            RegDateTime = regDateTime;
            EmployeeId = employeeId;
        }

        public Vacation()
        {
        }
    }
}
