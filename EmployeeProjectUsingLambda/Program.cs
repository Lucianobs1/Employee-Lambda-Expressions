using EmployeeProjectUsingLambda.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace EmployeeProjectUsingLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter salary: ");
            double referenceSalary = double.Parse(Console.ReadLine());
            Console.WriteLine();

            List<Employee> Employees = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {

                while (!sr.EndOfStream)
                {
                    string[] result = sr.ReadLine().Split(',');
                    string name = result[0];
                    string email = result[1];
                    double salary = double.Parse(result[2], CultureInfo.InvariantCulture);

                    Employees.Add(new Employee(name, email, salary));
                }

                var ShowEmail = Employees.Where(x => x.Salary > referenceSalary).OrderBy(x => x.Email).Select(x => x.Email);

                var ShowSalary = Employees.Where(x => x.Name[0] == 'M').Select(x => x.Salary).Sum();

                foreach (string item in ShowEmail)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();

                Console.Write("Total Sum: " + ShowSalary, "F2", CultureInfo.InstalledUICulture);

            }

            Console.ReadKey();
        }
    }
}
