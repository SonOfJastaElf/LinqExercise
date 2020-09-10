using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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

            //Done: Print the Sum and Average of numbers
            var sum = numbers.Sum();
            var avg = numbers.Average();
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: {avg}");
            Console.WriteLine("-----------------------------");

            //Done: Order numbers in ascending order and decsending order. Print each to console.

            var ascend = numbers.OrderBy(num => num);
            Console.WriteLine("Ascending Numbers:");
            foreach (var num in ascend)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("--------------------------------");
            var descend = numbers.OrderByDescending(x => x);
            Console.WriteLine("Descending numbers:");
            foreach (var x in descend)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("----------------------------------");

            //Done: Print to the console only the numbers greater than 6
            Console.WriteLine("Now let's see only numbers that are 6 or higher:");
            var sixAndUp = numbers.Where(x => x >= 6);
            foreach (var x in sixAndUp)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("----------------------------------");

            //Done: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Now let's take four random numbers:");
            foreach(var num in ascend.Take(4))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("------------------------------------");
            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Changing one of the numbers to my age, we get:");
            numbers[4] = 37;
            foreach (var num in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("------------------------------------");
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Done: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Done: Order this in acesnding order by FirstName.
            Console.WriteLine("And now for a list of employees with C or S names:");
            var selectedNames = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);
            foreach (var employee in selectedNames)
            {
                Console.WriteLine(employee.FullName);
            }
            Console.WriteLine("---------------------------------------");

            //Done: Print all the employees' FullName and Age who are over the age 26 to the console.
            //Done :Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Now to list only the employees aged 26 or over:");
            var twentySixAndOver = employees.Where(person => person.Age >= 26).OrderBy(employee => employee.Age).ThenBy(employee => employee.FirstName);
            foreach(var person in twentySixAndOver)
            {
                Console.WriteLine($"Name: {person.FullName} Age:{person.Age}");
            }
            Console.WriteLine("---------------------------------------");

            //Done: Print the Sum and then the Average of the employees' YearsOfExperience
            //Done: if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("Lastly, let's add up and take the average of the employees' years of experience:");
            var years = employees.Where(x => x.YearsOfExperience <= 10 && x.Age >= 35);
            var yearSum = years.Sum(employee => employee.YearsOfExperience);
            var yearAverage = years.Average(Employee => Employee.YearsOfExperience);

            Console.WriteLine($"Sum: {yearSum} Average: {yearAverage}");
            Console.WriteLine("------------------------------------------");

            //Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("firstName", "lastName", 25, 3)).ToList();

            foreach(var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.Age}");
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
