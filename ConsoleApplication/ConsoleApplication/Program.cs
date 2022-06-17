using ConsoleAppClassLibrary;
using ConsoleAppClassLibrary.Enums;
using System;

namespace ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("department")
            {
                Name = "eli",
                EmployeeType = EmployeeType.Adjunct,

            };
            Console.WriteLine(employee.EmployeeType);
            
        }
    }
}
