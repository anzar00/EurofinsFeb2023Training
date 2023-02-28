using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRecommendationEngine.Common.Entities
{
    public class BookDetails
    {
        //BookDetails has many Book
        public List<Book> Books { get; set; } = new List<Book>();

        //BookDetails has many BookUserRating
        public List<BookUserRating> BookUserRatings { get; set; } = new List<BookUserRating>();

        //BookDetails has many User
        public List<User> Users { get; set; } = new List<User>();
    }
}
