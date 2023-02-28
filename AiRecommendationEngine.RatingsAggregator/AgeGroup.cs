using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRecommendationEngine.RatingsAggregator
{
    public class AgeGroup : IAgeGroup
    {
        //Get AgeGroup method returns the age group of the user based on thier age
        //Age Gropus
        //1 - 16 - Teen Age
        //17 - 30 - Young Age
        //31 - 50 - Mid Age
        //51 - 60 - Old Age
        //61 - 100 - Senior Citizens
        
        private int[] AgeLimits = { 16, 30, 50, 60, 100 };
        public int GetAgeGroup(int age)
        {
            int ageGroup = 0;
            for (int i = 0; i < AgeLimits.Length; i++)
            {
                if (age <= AgeLimits[i])
                {
                    ageGroup = i + 1;
                    break;
                }
            }
            return ageGroup;
        }

    }
}
