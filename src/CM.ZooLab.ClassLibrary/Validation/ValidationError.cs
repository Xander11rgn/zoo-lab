using System;
using System.Collections.Generic;
using System.Text;

namespace CM.ZooLab.ClassLibrary
{
    public class ValidationError
    {
        public string Error 
        { 
            get;
            private set;
        }
        public ValidationError(string message)
        {
            Error = message;
        }
    }
}
