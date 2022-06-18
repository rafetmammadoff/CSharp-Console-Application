using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClassLibrary.Exceptions
{
    public class DepartamentNotFoundException:Exception
    {
        public DepartamentNotFoundException(string msg) :base(msg)
        {

        }
    }
}
