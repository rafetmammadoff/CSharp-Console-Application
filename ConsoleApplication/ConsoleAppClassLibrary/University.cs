using ConsoleAppClassLibrary.Exceptions;
using ConsoleAppClassLibrary.Extentions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClassLibrary
{
    public class University : IUniversity
    {
        public University(int salaryLimit)
        {
            SalaryLimit = salaryLimit;
        }
        private string _name;
        private int _workerLimit;
        private int _salaryLimit;
        private Employee[] _employees=new Employee[0];
        private Student[] _students=new Student[0];
        public string Name
        {
            get => _name;
            set
            {
                if (CheckName(value))
                {
                    _name = value;
                }
            }
        }
        public int WorkerLimit
        {
            get => _workerLimit;
            set
            {
                if (value>0)
                {
                    _workerLimit = value;
                }
            }
        }
        public int SalaryLimit
        {
            get => _salaryLimit;
            set
            {
                if (value>=250)
                {
                    _salaryLimit = value;
                }
            }
        }
        public Employee[] Employees => _employees;

        public Student[] Students => _students;

        public void AddEmployee(Employee employee)
        {
            if (_employees.Length<WorkerLimit && (_employees.CalcTotalSalary() + employee.Salary<= SalaryLimit))
            {
                Array.Resize(ref _employees, _employees.Length + 1);
                _employees[_employees.Length - 1] = employee;
            }
        }
        

        public void AddStudent(Student student)
        {
            Array.Resize(ref _students, _students.Length + 1);
            _students[_students.Length - 1] = student;
        }

        public int CalcSalaryAverage()
        {
            int totalSalary = 0;
            if (_employees.Length>0)
            {
                for (int i = 0; i < _employees.Length; i++)
                {
                    totalSalary += _employees[i].Salary;
                }
                return totalSalary / _employees.Length;
            }
            return 0;
        }

        public int CalcStudentAverage()
        {
            int totalPoint = 0;
            if (_students.Length > 0)
            {
                for (int i = 0; i < _students.Length; i++)
                {
                    totalPoint += _students[i].Point;
                }
                return totalPoint / _students.Length;
            }
            else
            {
                throw new StudentNotFoundException($"Universitetde oxuyan telebe yoxdur");
            }
            return 0;
        }

        public int CalcStudentAverage(string groupNo)
        {
            int totalPoint = 0;
            int count = 0;
            
            
                for (int i = 0; i < _students.Length; i++)
                {
                    if (_students[i].GroupNo==groupNo)
                    {
                        totalPoint += _students[i].Point;
                        count++;
                    }
                }
                if (count>0)
                {
                    return totalPoint / count;
                }
                if (count==0)
                {
                    throw new StudentNotFoundException($"{groupNo} qrupunda oxuyan telebe yoxdur");
                }
            
            return 0;
        }

        public void DeleteEmployee(string no)
        {
            int index = GetEmployeeIndex(no);
            if (index != -1)
            {
                for (int i = index; i < _employees.Length-1; i++)
                {
                    _employees[i] = _employees[i + 1];
                }
                Array.Resize(ref _employees, _employees.Length - 1);
            }
        }

        public void UpdateEmployee(string no,string newPosition,int newSalary)
        {
            int index = GetEmployeeIndex(no);
            if (index != -1)
            {
                _employees[index].Position=newPosition;
                _employees[index].Salary=newSalary;
            }
        }

        public void UpdateStudent(string no,string newGroupNo)
        {
            int index = GetStudentIndex(no);
            if (index==-1)
            {
                throw new StudentNoNotFoundException($"{no} nomreli student tapilmadi");
            }
            if (index != -1)
            {
                _students[index].GroupNo = newGroupNo;
            }
        }

        public static bool CheckName(string text)
        {
            if (!String.IsNullOrWhiteSpace(text) && text.Length > 1)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (!Char.IsLetter(text[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public int GetEmployeeIndex(string no)
        {
            if (_employees.Length>0)
            {
                for (int i = 0; i < _employees.Length; i++)
                {
                    if (_employees[i].No==no)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public int GetStudentIndex(string no)
        {
            if (_students.Length > 0)
            {
                for (int i = 0; i < _students.Length; i++)
                {
                    if (_students[i].StudentNo == no)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static void ShowEmployees(Employee[] employees)
        {
            foreach (var item in employees)
            {
                Console.WriteLine($"FullName:{item.FullName} - Salary:{item.Salary} - Departament:{item.DepartamentName} - No:{item.No}");
            }
        }

        public static void ShowEmployees(Employee[] employees,string departament)
        {
            foreach (var item in employees)
            {
                if (item.DepartamentName==departament)
                {
                    Console.WriteLine($"FullName:{item.FullName} - Salary:{item.Salary} - Departament:{item.DepartamentName} - No:{item.No} - Position:{item.Position}");
                }
            }
        }

        public static bool HasDepartment(Employee[] employees,string department)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].DepartamentName==department)
                {
                    return true;
                }
            }
            return false;
        }



    }
}
