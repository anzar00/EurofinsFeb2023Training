using AiRecommendationEngine.Common.Entities;
using AiRecommendationEngine.RatingsAggregator;
using AiRecommendationEngine.Integrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiRecommendationEngine.DataLoader;
using AiRecommendationEngine.CoreRecommender;

namespace AiRecommendationEngine.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create instances of the implementations
            IDataLoader dataLoader = new CSVDataLoader();
            IRecommender recommender = new PearsonCorrelation();
            IAggregator aggregator = new AiRecommendationEngine.RatingsAggregator.RatingsAggregator();

            // Create a new instance of AI Recommendation Engine
            AIRecommendationEngine aiRecommendationEngine = new AIRecommendationEngine(dataLoader, recommender, aggregator);

            while (true)
            {
                // Ask the user to enter Preference values
                Console.WriteLine("Enter the Preference values for the following categories:");
                Console.WriteLine("ISBN");
                string isbn = Console.ReadLine();
                Console.WriteLine("Age");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("State");
                string state = Console.ReadLine();

                // Create a new instance of Preference
                Preference preference = new Preference();
                preference.ISBN = isbn;
                preference.Age = age;
                preference.State = state;

                IList<Book> topBooks;

                topBooks = aiRecommendationEngine.Recommend(preference, 10);

                // Print the recommended books

                Console.WriteLine("Recommended Books:");
                
                // If no recommendations, print no books found else list ISBN and Book title

                if (topBooks.Count == 0)
                {
                    Console.WriteLine("No books found");
                }
                else
                {
                    foreach (Book book in topBooks)
                    {
                        Console.WriteLine($"ISBN - {book.ISBN}");
                        Console.WriteLine($"Title - {book.BookTitle}");
                    }
                }
            }
        }
    }
}
