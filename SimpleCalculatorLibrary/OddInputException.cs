using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorLibrary
{
    public class OddInputException : ApplicationException
    {
        public OddInputException(string message = null, Exception inner = null) : base(message, inner)
        {

        }
    }
}
