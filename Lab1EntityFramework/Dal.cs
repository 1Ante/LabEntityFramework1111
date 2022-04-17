using Lab1EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lab1EntityFramework
{
    //Dal = "Data layer". Klassen innehåller metoder för programmets funktioner
    public class Dal
    {
        
        public List<Employee> GetEmployees()
        {
            List<Employee> tempList = new List<Employee>();

            using EmployeeVacation context = new EmployeeVacation();
            {
                var employees = context.Employees.ToList();

                foreach (var item in employees)
                { 
                    tempList.Add(item);
                }
            }

            return tempList;
        }

        public void GetSpecificEmployee(int employeeId)
        {

            using EmployeeVacation context = new EmployeeVacation();
            {
                var results = from a in context.Employees
                              join b in context.Vacations on a.EmployeeId equals b.EmployeeId
                              where a.EmployeeId == employeeId && b.EmployeeId == employeeId
                              select new {a.FirstName, a.LastName, b.VacationType, b.StartDate, b.EndDate, b.RegDateTime };

                //Lägger "results" i en lista
                var list = results.Select(s => new { FirstName = s.FirstName, LastName = s.LastName, VacationType = s.VacationType, StartDate = s.StartDate, EndDate = s.EndDate, RegDateTime =
                    s.RegDateTime}).ToList();

                //Om listan inte är tom ska resultatet av queryn skrivas ut
                if (list.Count != 0)
                {
                    foreach (var item in list)
                    {
                        Console.WriteLine("Namn: " + $"{item.FirstName}" + " " + $"{item.LastName}\n" + "Ledighetstyp:" + " " +
                           $"{item.VacationType}\n" + "Startdatum:" + " " + $"{item.StartDate}\n" + "Slutdatum:" + $"{item.EndDate}\n"
                           + "Registrerad:" + " " + $"{item.RegDateTime}\n");
                    }
                } //Om listan är tom har personen inga ansökningar
                else if (list.Count == 0)
                {
                    Console.WriteLine("Personen har inte sökt ledighet.");
                    Console.WriteLine();
                }

            }

        }

        public void AddVacation(string vacationType, DateTime startDate, DateTime endDate, DateTime regDateTime, int employeeId)
        {
            using EmployeeVacation context = new EmployeeVacation();
            {
                var vacation = new Vacation()
                {
                    VacationType = vacationType,
                    StartDate = startDate,
                    EndDate = endDate,
                    RegDateTime = DateTime.Now.Date,
                    EmployeeId = employeeId
                };

                context.Add(vacation);
                context.SaveChanges();
            }
        }

        public void GetApplications(DateTime startDate, DateTime endDate)
        {
         
            using EmployeeVacation context = new EmployeeVacation();
            {
                var results = from a in context.Employees
                              join b in context.Vacations on a.EmployeeId equals b.EmployeeId
                              where b.RegDateTime >= startDate && b.RegDateTime <= endDate 
                              let dayDiff = (b.EndDate - b.StartDate).TotalDays
                              select new { a.FirstName, a.LastName, b.VacationType, b.StartDate, b.EndDate, b.RegDateTime, dayDiff };

                //Lägger "results" i en lista
                var list = results.Select(s => new { FirstName = s.FirstName, LastName = s.LastName, 
                    VacationType = s.VacationType, StartDate = s.StartDate, EndDate = s.EndDate, 
                    RegDateTime = s.RegDateTime, dayDiff = s.dayDiff  }).ToList();

                //Om listan inte är tom ska resultatet av queryn skrivas ut
                if (list.Count != 0)
                {
                    foreach (var item in list)
                    {
                        Console.WriteLine("Namn: " + $"{item.FirstName}" + " " + $"{item.LastName}\n" + "Ledighetstyp:" + " " +
                           $"{item.VacationType}\n" + "Startdatum:" + " " + $"{item.StartDate}\n" + "Slutdatum:" + " " + $"{item.EndDate}\n"
                           + "Antal lediga dagar:" + " " + $"{item.dayDiff}\n" + "Registrerad:" + " " + $"{item.RegDateTime}\n");
                    }
                }//Om listan är tom finns inga ansökningar
                else if (list.Count == 0)
                {
                    Console.WriteLine("Inga ansökningar.");
                    Console.WriteLine();
                }

            }

        }
    }
}
