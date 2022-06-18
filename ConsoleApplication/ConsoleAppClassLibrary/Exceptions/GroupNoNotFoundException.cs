using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClassLibrary.Exceptions
{
    public class GroupNoNotFoundException : Exception
    {
        public GroupNoNotFoundException(string msg) : base(msg)
        {

        }
    }
}
