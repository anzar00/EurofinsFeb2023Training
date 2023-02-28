using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRecommendationEngine.DataLoader.Entities
{
    public class BookUserRating
    {
        //BookUserRating entity with Rating, ISBN, UserID
        public int Rating { get; set; }
        public string ISBN { get; set; }
        public int UserID { get; set; }

        //BookUserRating has a Book 
        public Book book = new Book();

        //BookUserRating has a User
        public User user = new User();
    }
}
