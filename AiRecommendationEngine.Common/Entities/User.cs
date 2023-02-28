using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRecommendationEngine.Common.Entities
{
    public class User
    {
        //User entity with UserID, Age, City, State, Country
        public int UserID { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        //User has 0 or many BookUserRating
        public List<BookUserRating> UserRatings { get; set; }
    }
}
