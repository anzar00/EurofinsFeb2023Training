using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        //Driver Code

        public static void Main(string[] args)
        {
            //Load data from CSV files
            IDataLoader dataLoader = new CSVDataLoader();
            BookDetails bookDetails = dataLoader.LoadData();

            //Get the list of books
            List<Book> books = bookDetails.Books;

            //Get the list of users
            List<User> users = bookDetails.Users;

            //Get the list of book ratings
            List<BookUserRating> bookRatings = bookDetails.BookUserRatings;

            //Get the list of books rated by user 276725
            List<BookUserRating> userRatings = bookRatings.Where(x => x.UserID == 276725).ToList();

            //Get the list of books rated by user 276725 and sort by rating
            List<BookUserRating> userRatingsSorted = userRatings.OrderByDescending(x => x.Rating).ToList();

            //Get the list of books rated by user 276725 and sort by rating and take top 5
            List<BookUserRating> userRatingsSortedTop5 = userRatingsSorted.Take(5).ToList();

            //Get the list of books rated by user 276725 and sort by rating and take top 5 and get the ISBN
            List<string> userRatingsSortedTop5ISBN = userRatingsSortedTop5.Select(x => x.ISBN).ToList();

            //Get the list of books rated by user 276725 and sort by rating and take top 5 and get the ISBN and get the book details
            List<Book> userRatingsSortedTop5ISBNBookDetails = books.Where(x => userRatingsSortedTop5ISBN.Contains(x.ISBN)).ToList();

            //Get the list of books rated by user 276725 and sort by rating and take top 5 and get the ISBN and get the book details and get the book title
            List<string> userRatingsSortedTop5ISBNBookDetailsBookTitle = userRatingsSortedTop5ISBNBookDetails.Select(x => x.BookTitle).ToList();

            //Get the list of books rated by user 276725 and sort by rating and take top 5 and get the ISBN and get the book details and get the book title and get the book author
            List<string> userRatingsSortedTop5ISBNBookDetailsBookTitleBookAuthor = userRatingsSortedTop5ISBNBookDetails.Select(x => x.BookAuthor).ToList();

            //
        }

    }

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

    public class BookDetails
    {
        //BookDetails has many Book
        public List<Book> Books { get; set; }

        //BookDetails has many BookUserRating
        public List<BookUserRating> BookUserRatings { get; set; }

        //BookDetails has many User
        public List<User> Users { get; set; }
    }

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
    public interface IDataLoader
    {
        // Load the data from the CSV files and return BookDetails
        BookDetails LoadData();
    }

    public class CSVDataLoader : IDataLoader
    {
        private const string BookRatingsFilePath = @"C:\Users/Admin\source\repos\EurofinsFeb2023DemoCode\AiRecommendationEngine.DataLoader\BX-Book-Rating.csv";
        private const string BooksFilePath = @"C:\Users/Admin\source\repos\EurofinsFeb2023DemoCode\AiRecommendationEngine.DataLoader\BX-Books.csv";
        private const string UsersFilePath = @"C:\Users/Admin\source\repos\EurofinsFeb2023DemoCode\AiRecommendationEngine.DataLoader\BX-Users.csv";
        public BookDetails LoadData()
        {
            var books = new List<Book>();
            var users = new List<User>();
            var bookRatings = new List<BookUserRating>();

            // Read books from CSV
            using (var reader = new StreamReader(BooksFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    var book = new Book
                    {
                        ISBN = values[0],
                        BookTitle = values[1],
                        BookAuthor = values[2],
                        YearOfPublication = int.Parse(values[3]),
                        Publisher = values[4],
                        ImageURLSmall = values[5],
                        ImageURLMedium = values[6],
                        ImageURLLarge = values[7]
                    };

                    books.Add(book);
                }
            }

            // Read users from CSV
            using (var reader = new StreamReader(UsersFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    var user = new User
                    {
                        UserID = int.Parse(values[0]),
                        Age = int.Parse(values[1]),
                        City = values[2],
                        State = values[3],
                        Country = values[4]
                    };

                    users.Add(user);
                }
            }

            // Read book ratings from CSV
            using (var reader = new StreamReader(BookRatingsFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    var bookUserRating = new BookUserRating
                    {
                        UserID = int.Parse(values[0]),
                        ISBN = values[1],
                        Rating = int.Parse(values[2])
                    };

                    // Find the book and user associated with this rating
                    bookUserRating.book = books.Find(b => b.ISBN == bookUserRating.ISBN);
                    bookUserRating.user = users.Find(u => u.UserID == bookUserRating.UserID);

                    bookRatings.Add(bookUserRating);
                }
            }

            return new BookDetails
            {
                Books = books,
                Users = users,
                BookUserRatings = bookRatings
            };
        }
    }
}

}