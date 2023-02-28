using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRecommendationEngine.CoreRecommender
{
    public class PearsonCorrelation : IRecommender
    {
        public double GetCorrelation(List<int> baseData, List<int> otherData)
        {
            //Class for implementing Pearson Correlation Coefficient following the rules:
            //1. Both lists should be of same length.
            //2. If any element contains 0, then add 1 to both corresponding elements.
            //3. If other list is smaller than the base list, then add 1 for the remaining elements in the other list.
            //4. If other list is larger than the base list, then trim the other list with the size of base list.

            //Check length of the two lists
            if (baseData.Count != otherData.Count)
            {
                //If other list is smaller than the base list, then add 1 for the remaining elements in the other list.
                if (otherData.Count < baseData.Count)
                {
                    for (int i = otherData.Count; i < baseData.Count; i++)
                    {
                        otherData.Add(1);
                    }
                }
                //If other list is larger than the base list, then trim the other list with the size of base list.
                else
                {
                    otherData = otherData.Take(baseData.Count).ToList();
                }
            }

            //Check if any element contains 0, then add 1 to both corresponding elements.
            for (int i = 0; i < baseData.Count; i++)
            {
                if (baseData[i] == 0)
                {
                    baseData[i] += 1;
                    if (otherData[i] != 10)
                    {
                        otherData[i] += 1;
                    }
                }
            }

            for (int i = 0; i < otherData.Count; i++)
            {
                if (otherData[i] == 0)
                {
                    otherData[i] += 1;
                    if (baseData[i] != 10)
                    {
                        baseData[i] += 1;
                    }
                }
            }

            //Calculate the Pearson Correlation Coefficient
            double sumBase = 0;
            double sumOther = 0;
            double sumBaseSquare = 0;
            double sumOtherSquare = 0;
            double sumBaseOther = 0;
            double n = baseData.Count;

            for (int i = 0; i < baseData.Count; i++)
            {
                sumBase += baseData[i];
                sumOther += otherData[i];
                sumBaseSquare += Math.Pow(baseData[i], 2);
                sumOtherSquare += Math.Pow(otherData[i], 2);
                sumBaseOther += baseData[i] * otherData[i];
            }

            double numerator = n * sumBaseOther - (sumBase * sumOther);
            double denominator = Math.Sqrt((n * sumBaseSquare - Math.Pow(sumBase, 2)) * (n * sumOtherSquare - Math.Pow(sumOther, 2)));

            return numerator / denominator;

        }
    }
    
}
