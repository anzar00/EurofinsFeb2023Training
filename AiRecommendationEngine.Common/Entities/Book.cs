using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRecommendationEngine.Common.Entities
{
    public class Book
    {
        //Book entity with BookTitle, BookAuthor, ISBN, Publisher,
        //YearOfPublication, ImageURLSmall, ImageURLMedium, ImageURLLarge

        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public int YearOfPublication { get; set; }
        public string ImageURLSmall { get; set; }
        public string ImageURLMedium { get; set; }
        public string ImageURLLarge { get; set; }

        //Book has 0 or many BookUserRating
        public List<BookUserRating> BookRatings { get; set; }

    }
}
