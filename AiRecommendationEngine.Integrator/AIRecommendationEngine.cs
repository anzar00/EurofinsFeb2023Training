using AiRecommendationEngine.Common.Entities;
using AiRecommendationEngine.CoreRecommender;
using AiRecommendationEngine.DataLoader;
using AiRecommendationEngine.RatingsAggregator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRecommendationEngine.Integrator
{
    public class AIRecommendationEngine
    {
        // Create an integrator that has the interfaces of the DataLoader, CoreRecommender and RatingsAggregator

        IDataLoader dataLoader;
        IRecommender recommender;
        IAggregator aggregator;

        BookDetails bookDetails;

        public AIRecommendationEngine()
        {
        }

        public AIRecommendationEngine(IDataLoader dataLoader, IRecommender recommender, IAggregator aggregator)
        {
            this.dataLoader = dataLoader;
            this.recommender = recommender;
            this.aggregator = aggregator;
            this.bookDetails = dataLoader.LoadData();
        }

        public IList<Book> Recommend(Preference preference, int limit)
        {
            //Books
            IList<Book> books = bookDetails.Books;
            
            //Get all books meeting the preference. Preference has Books ISBN, Age and State of reader. 
            //Use the RatingsAggregator to get the books that meet the preference
            // Get recommendation for each book in the list of books that meet the preference
            //Get the correlation between the book and the preference
            // Sort the correlations dictionary in descending order of correlation value
            // Get the top n (limit) books with the highest correlation
            // Return the top n books
            Dictionary<string, List<int>> ratings = aggregator.Aggregate(bookDetails, preference);
            
            Dictionary<string, double> correlations = new Dictionary<string, double>();
            foreach (KeyValuePair<string, List<int>> rating in ratings)
            {
                double correlation = recommender.GetCorrelation(ratings[preference.ISBN],rating.Value);
                correlations.Add(rating.Key, correlation);
            }

            var sortedCorrelations = correlations.OrderByDescending(x => x.Value);

            IList<Book> topBooks = new List<Book>();
            int count = 0;
            foreach (KeyValuePair<string, double> sortedCorrelation in sortedCorrelations)
            {
                if (count < limit)
                {
                    foreach (Book book in books)
                    {
                        if (book.ISBN == sortedCorrelation.Key)
                        {
                            topBooks.Add(book);
                            count++;
                        }
                    }
                }
            }
            
            return topBooks;
        }
    }
}
