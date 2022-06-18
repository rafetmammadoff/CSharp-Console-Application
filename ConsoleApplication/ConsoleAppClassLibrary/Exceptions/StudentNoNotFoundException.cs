using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClassLibrary.Exceptions
{
    public class StudentNoNotFoundException : Exception
    {
        public StudentNoNotFoundException(string msg) : base(msg)
        {

        }
    }
}
