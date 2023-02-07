using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMarks.Business
{
    public class PassClass
    {
        //1st class is for a score of 60 and above
        //2nd is for a score of 50 and above, while 
        //pass class is for a score of 35 and above.If the score is less than 35, then the student
        //fails.

        public static string StudentResult(float average)
        {
            if (average >= 60)
            {
                return "1st Class";
            }
            else if(average >= 50 & average < 60)
            {
                return "2nd Class";
            }
            else if(average >= 35 & average < 50)
            {
                return "Pass";
            }
            else
            {
                return "Fail";
            }

        }
    }
}
