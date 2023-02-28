using AiRecommendationEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRecommendationEngine.RatingsAggregator
{
    public class RatingsAggregator : IAggregator
    {
        public Dictionary<string, List<int>> Aggregate(BookDetails bookDetails, Preference preference)
        {
            ////Collect all ratings for each book based on preference and return 
            //Dictionary<string, List<int>> ratings = new Dictionary<string, List<int>>();

            //// fill the ratings

            //return ratings;

            Dictionary<string, List<int>> ratings = new Dictionary<string, List<int>>();
            foreach (var item in bookDetails)
            {
                if (item.book.State == preference.State && item.book.Age == preference.Age)
                {
                    if (ratings.ContainsKey(item.ISBN))
                    {
                        ratings[item.ISBN].Add(item.Rating);
                    }
                    else
                    {
                        ratings.Add(item.ISBN, new List<int>() { item.Rating });
                    }
                }
            }
            return ratings;
        }
    }
}
