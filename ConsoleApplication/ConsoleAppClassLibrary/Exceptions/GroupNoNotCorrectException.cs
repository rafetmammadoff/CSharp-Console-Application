using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClassLibrary.Exceptions
{
    public class GroupNoNotCorrectException : Exception
    {
        public GroupNoNotCorrectException(string msg) : base(msg)
        {

        }
    }
}
