using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers - DONE

            var results = numbers.Sum();
            
            Console.WriteLine(results);

            var results2 = numbers.Average();

            Console.WriteLine(results2);


            //Order numbers in ascending order and decsending order. Print each to console. - DONE

            var result3 = numbers.OrderByDescending(Sort => Sort);
            foreach (var n in result3)
            {
                Console.WriteLine(n);
            }

            var result4 = numbers.OrderBy(Sort => Sort);
            foreach (var n in result4)
            {
                Console.WriteLine(n);
            }

            //Print to the console only the numbers greater than 6 - DONE

            var result5 = numbers.Where(y => y > 6);
            foreach (var n in result5)
            {
                Console.WriteLine(n);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!** - DONE

            var result6 = numbers.Take(4);
            foreach (var n in result6)
            {
                Console.WriteLine(n);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order

            numbers[4] = 39;
            foreach (var num in numbers.OrderByDescending(y => y))
                Console.WriteLine(num);

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var filtered = employees.Where(x => x.FirstName.StartsWith('C')|| x.FirstName.StartsWith('S'));
            filtered.OrderBy(x => x.FirstName);

            Console.WriteLine("C or S Employees");
            foreach (var num in filtered)
            {
                Console.WriteLine(num.FirstName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(x => x.Age > 26);
            overTwentySix.OrderBy(y => y.Age).ThenBy(z => z.FirstName);

            Console.WriteLine("Over 26");
            foreach (var num in overTwentySix)
            {
                Console.WriteLine($"Full Name:{num.FullName}, Age:{num.Age}");
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var years = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var sum = employees.Sum(y => y.YearsOfExperience);
            var avg = employees.Average(z => z.YearsOfExperience);

            Console.WriteLine($"Sum: {sum} Average: {avg}");

            //Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("Bob", "Sorge", 60, 1)).ToList();

            foreach (var item in employees)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} {item.Age}");
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
