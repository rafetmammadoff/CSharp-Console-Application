using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClassLibrary
{
    internal class University : IUniversity
    {
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
            if (_employees.Length<WorkerLimit)
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
            return 0;
        }

        public int CalcStudentAverage(string groupNo)
        {
            int totalPoint = 0;
            int count = 0;
            if (_students.Length>0)
            {
                for (int i = 0; i < _students.Length; i++)
                {
                    if (_students[i].GroupNo==groupNo)
                    {
                        totalPoint += _students[i].Point;
                        count++;
                    }
                }
                return totalPoint /count;
            }
            return 0;
        }

        public void DeleteEmployee()
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee()
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent()
        {
            throw new NotImplementedException();
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

        
    }
}
