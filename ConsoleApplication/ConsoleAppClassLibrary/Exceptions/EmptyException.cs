using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClassLibrary.Exceptions
{
    public class EmptyException : Exception
    {
        public EmptyException(string msg) : base(msg)
        {

        }
    }
}
