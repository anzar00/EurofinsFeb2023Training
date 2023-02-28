using AiRecommendationEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRecommendationEngine.DataLoader
{
    public class CSVDataLoader : IDataLoader
    {
        private string BookRatingsFilePath = @"../../BX-Book-Rating.csv";
        private string BooksFilePath = @"../../BX-Books.csv";
        private string UsersFilePath = @"../../BX-Users.csv";
        public BookDetails LoadData()
        {
            var books = new List<Book>();
            var users = new List<User>();
            var bookRatings = new List<BookUserRating>();

            // Read books from CSV
            using (var reader = new StreamReader(BooksFilePath))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    var book = new Book
                    {
                        ISBN = values[0].Trim('"'),
                        BookTitle = values[1].Trim('"'),
                        BookAuthor = values[2].Trim('"'),
                        YearOfPublication = int.Parse(values[3].Trim('"')),
                        Publisher = values[4].Trim('"'),
                        ImageURLSmall = values[5].Trim('"'),
                        ImageURLMedium = values[6].Trim('"'),
                        ImageURLLarge = values[7].Trim('"')
                    };
                    books.Add(book);
                }
            }

            // Read users from CSV
            using (var reader = new StreamReader(UsersFilePath))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    var user = new User
                    {
                        UserID = int.Parse(values[0].Trim('"')),
                        Age = int.Parse(values[2].Trim('"'))
                    };

                    var address = values[1].Trim('"').Split(',');

                    if (address.Length == 3)
                    {
                        user.City = address[0].Trim();
                        user.State = address[1].Trim();
                        user.Country = address[2].Trim();
                    }
                    else if (address.Length == 2)
                    {
                        user.City = address[0].Trim();
                        user.State = "";
                        user.Country = address[1].Trim();
                    }
                    else
                    {
                        user.City = address[0].Trim();
                        user.State = "";
                        user.Country = "";
                    }

                    users.Add(user);
                }
            }



             // Read book ratings from CSV
            using (var reader = new StreamReader(BookRatingsFilePath))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    var bookUserRating = new BookUserRating
                    {
                        UserID = int.Parse(values[0].Trim('"')),
                        ISBN = values[1].Trim('"'),
                        Rating = int.Parse(values[2].Trim('"'))
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