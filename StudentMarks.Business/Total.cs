using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMarks.Business // BL
{
    public class Total
    {
        public static int TotalMarks(int maths, int physics, int chemistry)
        {
            return maths + physics + chemistry;
        }
    }
}
