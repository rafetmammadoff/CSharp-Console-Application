using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClassLibrary.Exceptions
{
    public class SalaryLimitException : Exception
    {
        public SalaryLimitException(string msg) : base(msg)
        {

        }
    }
}
