using ConsoleAppClassLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClassLibrary
{
    public  class Employee
    {
        static Employee()
        {
            _totalCount = 1000;
        }
        public Employee(string departamentName)
        {
            DepartamentName = departamentName;
            No = DepartamentName.Substring(0, 2).ToUpper() + _totalCount;
            _totalCount++;
        }
        private  string _departamentName;
        public string  DepartamentName
        {
            get { return _departamentName; }
            set
            {
                if (CheckNameSurnameDepartamentName(value))
                {
                    _departamentName = value;
                }
            }
        }
        private static int _totalCount;
        public int TotalCount => _totalCount;
        public string  No { get;}
        private  string _name;
        private string _surname;
        private string _position;
        private int _salary;
        public string FullName
        {
            get
            {
                return _name +" "+ _surname;
            }
        }
        public string  Name
        {
            get => _name;
            set
            {
                if (CheckNameSurnameDepartamentName(value))
                {
                    _name = value;
                }
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                if (CheckNameSurnameDepartamentName(value))
                {
                    _surname = value;
                }
            }
        }
        public string Position
        {
            get => _position;
            set
            {
                if (CheckPosition(value))
                {
                    _position = value;
                }
            }
        }
        public int Salary
        {
            get => _salary;
            set
            {
                if (value>=250)
                {
                    _salary = value;
                }
            }
        }
        public static  bool CheckNameSurnameDepartamentName(string text)
        {
            if (!String.IsNullOrWhiteSpace(text) && text.Length>2)
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
        public static bool CheckPosition(string text)
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
        public EmployeeType EmployeeType;



    }
}
