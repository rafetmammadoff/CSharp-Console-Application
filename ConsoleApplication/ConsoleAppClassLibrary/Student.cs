using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClassLibrary
{
    public class Student
    {
        public Student()
        {
            _totalCount++;
            _studentNo = "ST" + _totalCount;
        }
        private string _name;
        private string _surname;
        private string _groupNo;
        private int _point;
        private static int _totalCount;
        private string _studentNo;
        public string  StudentNo
        {
            get => _studentNo;

        }

        public int Point
        {
            get => _point;
            set
            {
                if (value>=0 && value<=100)
                {
                    _point = value;
                }
            }
        }
        public string GroupNo
        {
            get => _groupNo;
            set
            {
                if (CheckGroupNo(value))
                {
                    _groupNo = value;
                }
            }
        }
        public string FullName
        {
            get
            {
                return _name + " " + _surname;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (CheckNameSurname(value))
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
                if (CheckNameSurname(value))
                {
                    _surname = value;
                }
            }
        }
        public static bool CheckNameSurname(string text)
        {
            if (!String.IsNullOrWhiteSpace(text) && text.Length > 2)
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
        public static bool CheckGroupNo(string groupNo)
        {
            if (!String.IsNullOrWhiteSpace(groupNo) && groupNo.Length==4 && Char.IsLetter(groupNo[0]))
            {
                for (int i = 1; i < groupNo.Length; i++)
                {
                    if (!Char.IsDigit(groupNo[i]))
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
