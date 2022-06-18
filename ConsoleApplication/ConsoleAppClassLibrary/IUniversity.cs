using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClassLibrary
{
    internal interface IUniversity
    {
        string  Name { get; set; }
        int WorkerLimit { get; set; }
        int SalaryLimit { get; set; }
        Employee[] Employees { get;}
        Student[] Students { get;}
        int CalcSalaryAverage();
        int CalcStudentAverage(string groupNo);
        int CalcStudentAverage();
        void AddEmployee(Employee employee);
        void AddStudent(Student student);
        void UpdateEmployee(string no, string newPosition, int salary);
        void UpdateStudent(string no, string newGroupNo);
        void DeleteEmployee(string no);
    }
}
