using AiRecommendationEngine.Common.Entities;
using AiRecommendationEngine.RatingsAggregator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace RatingsAggregator.Test
{
    [TestClass]
    public class UnitTest1
    {
        BookDetails details;
        IAggregator aggregator;
        [TestInitialize]
        public void Init()
        {
            aggregator = new AiRecommendationEngine.RatingsAggregator.RatingsAggregator();
            details = new BookDetails();
            Book book = new Book()
            {
                ISBN = "74108520",
            };
            Book book1 = new Book()
            {
                ISBN = "98765432"
            };
            Book book2 = new Book()
            {
                ISBN = "98764545"
            };
            User user = new User()
            {
                UserID = 1,
                Age = 25,
                State = "Alabama"
            };
            User user1 = new User()
            {
                UserID = 2,
                Age = 135,
                State = "Kimolasa"
            };
            User user2 = new User()
            {
                UserID = 3,
                Age = 17,
                State = "Alabama"
            };
            BookUserRating rating = new BookUserRating()
            {
                UserID = user1.UserID,
                book = book,
                Rating = 5,
                user = user1,
                ISBN = book.ISBN
            };
            user1.UserRatings.Add(rating);
            book.BookRatings.Add(rating);
            BookUserRating rating1 = new BookUserRating()
            {
                UserID = user2.UserID,
                user = user2,
                Rating = 6,
                book = book,
                ISBN=book.ISBN
            };
            user2.UserRatings.Add(rating1);
            book.BookRatings.Add(rating1);
            BookUserRating rating2 = new BookUserRating()
            {
                UserID = user.UserID,
                book = book1,
                Rating = 9,
                user = user,
                ISBN = book1.ISBN
            };
            user.UserRatings.Add(rating2);
            book1.BookRatings.Add(rating2); 
            BookUserRating rating3 = new BookUserRating()
            {
                UserID = user.UserID,
                book = book,
                Rating = -1,
                user = user,
                ISBN = book.ISBN
            };
            user.UserRatings.Add(rating3);
            book.BookRatings.Add(rating3);
            BookUserRating rating4 = new BookUserRating()
            {
                UserID = user.UserID,
                book = book2,
                Rating = 19,
                user = user,
                ISBN = book2.ISBN
            };
            user.UserRatings.Add(rating4);
            book2.BookRatings.Add(rating4); 
            details.Users.Add(user);
            details.Users.Add(user1);
            details.Users.Add(user2); 
            details.Books.Add(book);
            details.Books.Add(book1);
            details.Books.Add(book2); 
            details.BookUserRatings.Add(rating);
            details.BookUserRatings.Add(rating1);
            details.BookUserRatings.Add(rating2);
            details.BookUserRatings.Add(rating3);
            details.BookUserRatings.Add(rating4);
        }
        [TestCleanup]
        public void Cleanup()
        {
            details = null;
        }
        [TestMethod]
        public void RatingsAggrigator_ValidInput_ValidOutput()
        {
            Preference preference = new Preference()
            {
                State = "Alabama",
                Age = 20
            };
            Dictionary<string, List<int>> result = aggregator.Aggregate(details, preference);
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }
        
    }
}
