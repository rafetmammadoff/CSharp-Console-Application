using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClassLibrary.Exceptions
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string msg) : base(msg)
        {

        }
    }
}
