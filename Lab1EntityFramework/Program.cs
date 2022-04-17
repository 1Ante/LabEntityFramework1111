using Lab1EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;


namespace Lab1EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //Skapar en instans av Dal för att komma åt klassens metoder
            Dal d = new Dal();

            List<Employee> employees = new List<Employee>();
            

            using EmployeeVacation context = new EmployeeVacation();


            //Lägger till anställda och semesteransökningar via kod för att ha data att arbeta med

            //Employee employee1 = new Employee("Anders", "Persson");
            //Employee employee2 = new Employee("Maria", "Johansson");
            //Employee employee3 = new Employee("Jonas", "Karlsson");
            //Employee employee4 = new Employee("Erik", "Persson");

            //context.Add(employee1);
            //context.Add(employee2);
            //context.Add(employee3);
            //context.Add(employee4);

            //context.SaveChanges();

            ////Vacation vacation1 = new Vacation("Semester", DateTime.Parse("2022-04-25"), DateTime.Parse("2022-05-05"), DateTime.Now.Date, 1);
            ////Vacation vacation2 = new Vacation("VAB", DateTime.Parse("2022-04-14"), DateTime.Parse("2022-04-20"), DateTime.Now.Date, 3);
            ////Vacation vacation3 = new Vacation("Tjänstledighet", DateTime.Parse("2022-05-01"), DateTime.Parse("2022-09-20"), DateTime.Now.Date, 2);
            ////Vacation vacation4 = new Vacation("Semester", DateTime.Parse("2022-04-20"), DateTime.Parse("2022-04-25"), DateTime.Now.Date, 2);
            ////Vacation vacation5 = new Vacation("Semester", DateTime.Parse("2022-06-05"), DateTime.Parse("2022-06-15"), DateTime.Now.Date, 3);
            ////Vacation vacation6 = new Vacation("VAB", DateTime.Parse("2022-04-14"), DateTime.Parse("2022-04-19"), DateTime.Now.Date, 1);

            ////context.Add(vacation1);
            ////context.Add(vacation2);
            ////context.Add(vacation3);
            ////context.Add(vacation4);
            ////context.Add(vacation5);
            ////context.Add(vacation6);

            ////context.SaveChanges();

            Console.WriteLine("Program för ledighetsansökningar");
            Console.WriteLine();
            bool keepLooping = true;
            while (keepLooping)
            {
                
                Console.WriteLine("Meny");
                Console.WriteLine();
                Console.WriteLine("1. Ansök om ledighet");
                Console.WriteLine("2. Hämta ledighetsansökan för en anställd");
                Console.WriteLine("3. Hämta alla ansökningar som skapats en viss period och se antal dagar en person har sökt ledighet och vilka\n   datum ansökan har skapats");
                Console.WriteLine();
                Console.WriteLine("Välj siffra i menyn och tryck ENTER.");
                string choice = Console.ReadLine();
                
                Console.WriteLine();
                if (choice == "1")
                {
                    string vacationType = "";
                    bool keepLopping2 = true;
                    while (keepLopping2)
                    {
                        Console.WriteLine("Välj typ av ledighet. Tryck siffra och sedan ENTER.");
                        Console.WriteLine();
                        Console.WriteLine("1. Semester");
                        Console.WriteLine("2. VAB");
                        Console.WriteLine("3. Tjänstledighet");
                        Console.WriteLine();
                        string choice2 = (Console.ReadLine());
                        Console.WriteLine();

                        if (choice2 == "1")
                        {
                            vacationType = "Semester";
                            keepLopping2 = false;
                        }
                        else if (choice2 == "2")
                        {
                            vacationType = "VAB";
                            keepLopping2 = false;
                        }
                        else if (choice2 == "3")
                        {
                            vacationType = "Tjänstledighet";
                            keepLopping2 = false;
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                        }

                    }

                    Console.WriteLine("Ledighetsansökan för" + " " + vacationType);
                    Console.WriteLine();
                    
                    Console.WriteLine("Personal:");
                    d.GetEmployees();
                    foreach (var item in d.GetEmployees())
                    {
                        employees.Add(item);
                    }
                    foreach (var item in employees)
                    {
                        Console.WriteLine($"{item.EmployeeId}" + " " + $"{item.FirstName}" + " " + $"{item.LastName}");

                    }

                    Console.WriteLine();
                    
                    int employeeId = 0;
                    bool keepLooping3 = true;
                    while (keepLooping3)
                    {
                        Console.WriteLine("Vem är du? Tryck siffra och sedan ENTER.");
                        Console.WriteLine();
                        
                        try
                        {
                            int input = int.Parse(Console.ReadLine());
                            if (input > 0 && input <= employees.Count)
                            {
                                employeeId = input;
                                keepLooping3 = false;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Ogiltigt val. Välj rätt siffra.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine();
                            Console.WriteLine("Ogiltigt val. Välj siffra.");
                        }


                    }

                    employees.Clear();

                    DateTime startDate = new DateTime();
                    bool keepLooping4 = true;
                    
                    while (keepLooping4)
                    {
                        Console.WriteLine("Ange startdatum (åååå-mm-dd) och tryck sedan ENTER");

                        if (DateTime.TryParse(Console.ReadLine(), out startDate))
                        {
                            keepLooping4 = false;
                        }
                        else
                        {
                            Console.WriteLine("Fel format. Försök igen");
                            Console.WriteLine();
                        }
                    }
                    
                    DateTime endDate = new DateTime();
                    bool keepLooping5 = true;
                    while (keepLooping5)
                    {
                        Console.WriteLine("Ange slutdatum (åååå-mm-dd) och tryck sedan ENTER");

                        if (DateTime.TryParse(Console.ReadLine(), out endDate))
                        {
                            keepLooping5 = false;
                        }
                        else
                        {
                            Console.WriteLine("Fel format. Försök igen");
                            Console.WriteLine();
                        }
                    }
                        
                    Console.WriteLine("Tryck på R och sedan ENTER för att registrera ansökan. Tryck på A och sedan ENTER för att avbryta ansökan.");
                    string choice3 = Console.ReadLine();
                    
                    if(choice3 == "R")
                    {
                        d.AddVacation(vacationType, startDate, endDate, DateTime.Now, employeeId);
                        Console.WriteLine("Ansökan är registrerad. Tryck ENTER för att återgå till huvudmenyn.");
                        Console.ReadLine();

                    }
                    else if (choice3 == "A")
                    {
                        Console.WriteLine();
                    }

                }
                else if (choice == "2")
                {
                    Console.WriteLine("Personal:");
                    d.GetEmployees();
                    foreach (var item in d.GetEmployees())
                    {
                        employees.Add(item);
                    }
                    foreach (var item in employees)
                    {
                        Console.WriteLine($"{item.EmployeeId}" + " " + $"{item.FirstName}" + " " + $"{item.LastName}");

                    }
                    Console.WriteLine();
                    
                    int employeeId = 0;
                    bool keepLooping6 = true;
                    while(keepLooping6)
                    {
                        Console.WriteLine("Välj en anställd för att visa ansökningar. Tryck siffra och sedan ENTER.");
                        
                        try
                        {
                            int input = int.Parse(Console.ReadLine());
                            if (input > 0 && input <= employees.Count)
                            {
                                employeeId = input;
                                keepLooping6 = false;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Ogiltigt val. Välj rätt siffra.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine();
                            Console.WriteLine("Ogiltigt val. Välj rätt siffra.");
                        }

                    }
                    
                    Console.WriteLine();
                    d.GetSpecificEmployee(employeeId);
                    employees.Clear();
                    Console.WriteLine("Tryck på ENTER för att återgå till huvudmenyn.");
                    Console.ReadLine();
                   
                }
                else if (choice == "3")
                {

                    DateTime startDate = new DateTime();
                    bool keepLooping7 = true;
                    while (keepLooping7)
                    {
                        Console.WriteLine("Ange från vilket ansökningsdatum som ansökningar ska visas (åååå-mm-dd) och tryck ENTER.");
                        if (DateTime.TryParse(Console.ReadLine(), out startDate))
                        {
                            Console.WriteLine();
                            keepLooping7 = false;
                        }
                        else
                        {
                            Console.WriteLine("Fel format. Försök igen");
                            Console.WriteLine();
                        }

                    }

                    DateTime endDate = new DateTime();
                    bool keepLooping8 = true;
                    while (keepLooping8)
                    {
                        Console.WriteLine("Ange till vilket ansökningsdatim som ansökningar ska visas (åååå-mm-dd) och tryck sedan ENTER.");
                        if (DateTime.TryParse(Console.ReadLine(), out endDate))
                        {
                            keepLooping8 = false;
                        }
                        else
                        {
                            Console.WriteLine("Fel format. Försök igen");
                            Console.WriteLine();
                        }
                    }

                    Console.WriteLine();
                    d.GetApplications(startDate, endDate);
                    Console.WriteLine("Tryck på ENTER för att återgå till huvudmenyn.");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("Välj en siffra. Försök igen.");
                    Console.WriteLine();
                }

                
            }
        }
    }
}
