using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.Business 
{
    public class Calculator //BL
    {
        public static int FindSum(int fno, int sno) // SRP - BL
        {
            return fno + sno;
        }
    }
}
