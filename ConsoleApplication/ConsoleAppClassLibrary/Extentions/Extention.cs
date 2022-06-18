using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClassLibrary.Extentions
{
    public static class Extention
    {
        public static int CalcTotalSalary(this Employee[] employees)
        {
            int totalSalary = 0;
            if (employees.Length>0)
            {
                foreach (var item in employees)
                {
                    totalSalary+=item.Salary;
                }
            }
            return totalSalary;
        }
    }
}
