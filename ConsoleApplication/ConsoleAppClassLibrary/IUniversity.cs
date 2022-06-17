using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClassLibrary
{
    internal interface IUniversity
    {
        // - Name - Universityin adini ifade edir, University adi minimum 2 herfden ibaret olmalidir
        // - WorkerLimit - Universityde maximum var ola bilicek isci sayini ifade edir, minimum 1 ola biler
        // - SalaryLimit - Universityde butun isceleri ayliq cemi verilecek maximum meblegi ifade edir, minimum 250 ola biler
        // - Employees - Universitydeki iscileri ifade edir.Universitye elave olunmus iscilerin siyahisini iafe edir
        // - Students - Universitydeki telebeleri ifade edir
        // - CalcSalaryAverage() - Universitydeki iscilerin maas ortalamasini qaytaran method
        // - CalcStudentsAverage() - Universitydeki telebelerin point ortalamasini hesablayir
        // - CalcStudentsAverage() - string groupno deyeri qebul edir ve hemin qrupdaki teleblerin point ortalamasini hesablayir
        // - AddEmployee() - employee obyektini employees-e elave edir
        // - AddStudent() - student obyektini students-e elave edir
        // - UpdateEmployee()
        //- StudentUpdate()
        // - DeleteEmployee()
        string  Name { get; set; }
        int WorkerLimit { get; set; }
        int SalaryLimit { get; set; }
        Employee[] Employees { get;}
        Student[] Students { get;}
        int CalcSalaryAverage();
        int CalcSalaryAverage(string groupNo);
        void AddEmployee(Employee employee);
        void AddStudent(Student student);
        void UpdateEmployee();
        void UpdateStudent();
        void DeleteEmployee();



    }
}
