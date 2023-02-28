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
            //Store all BookUserRatings in a dictionary with key as ISBN and value as list of ratings 
            //for that ISBN where the user is from the same state and age group as the preference
            Dictionary<string, List<int>> ratings = new Dictionary<string, List<int>>();
            AgeGroup ageGroup = new AgeGroup();

            foreach(Book book in bookDetails.Books)
            {
                foreach(BookUserRating bookUserRating in bookDetails.BookUserRatings)
                {
                    if (ageGroup.GetAgeGroup(bookUserRating.user.Age) == ageGroup.GetAgeGroup(preference.Age) && bookUserRating.user.State == (preference.State))
                    {
                        foreach(User user in bookDetails.Users)
                        {
                            if(user.UserID == bookUserRating.UserID)
                            {
                                if(ratings.ContainsKey(book.ISBN))
                                {
                                    ratings[book.ISBN].Add(bookUserRating.Rating);
                                }
                                else
                                {
                                    ratings.Add(book.ISBN, new List<int>() { bookUserRating.Rating });
                                }
                            }
                        }
                    }
                }
            }
            return ratings;
        }
    }
}
