using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrazyProductsCatalog.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //URL: https://localhost:44309/api/crazyproducts
            string baseUrl = "https://localhost:44309/api/crazyproducts";

            HttpClient client = new HttpClient();

            var result = client.GetStringAsync(baseUrl).Result;
            string products = client.GetStringAsync(baseUrl).GetAwaiter().GetResult();
            Console.WriteLine(products);

            var responseMessage = client.GetAsync(baseUrl).Result;

            if(responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = responseMessage.Content;
                var productsList = content.ReadAsAsync<List<Product>>().Result;

                foreach (var product in productsList)
                {
                    Console.WriteLine(product.Name);
                }
            }
        }
    }
}
