using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("1. List all products whose price in between 50K to 80K");
            var products = ProductsDB.GetProducts();
            var products5080 = from p in products
                                where p.Price >= 50000 && p.Price <= 80000
                                select p;
           
            foreach (var product in products5080)
            {
                Console.WriteLine(product.Name);
            }


            Console.WriteLine("2. Extract all products belongs to Laptops catagory");
            var productsLaptops = from p in products
                                  where p.Catagory.Name == "Laptops"
                                  select p;
            foreach (var product in productsLaptops)
            {
                Console.WriteLine(product.Name);
            }

            Console.WriteLine("3. Extract/Show Product Name and Catagory Name only");

            var productsPC = from p in products
                             select p;
            Console.WriteLine("Product Name \t Category Name");
            foreach (var product in productsPC)
            {
                Console.WriteLine($"{product.Name} \t {product.Catagory.Name}");
            }

            Console.WriteLine("4. Show the costliest product name ");

            var productsCostliest = from p in products
                                    orderby p.Price descending
                                    select p;

            // Print costliest product details 
            Console.WriteLine(productsCostliest.First().Name);

            Console.WriteLine("5. Show the cheepest product name and its price");

            var productsCheepest = from p in products
                                   orderby p.Price ascending
                                   select p;

            // Print cheepest product details
            Console.WriteLine(productsCheepest.First().Name);

            Console.WriteLine("6. Show the 2nd and 3rd product details");

            Console.WriteLine(products[1].Name +" "+ products[1].Catagory.Name);
            Console.WriteLine(products[2].Name +" "+ products[2].Catagory.Name);

            Console.WriteLine("7. List all products in assending order of their price");

            var productsPrice = from p in products
                                orderby p.Price ascending
                                select p;

            foreach (var product in productsPrice)
            {
                Console.WriteLine($"{product.Name} \t {product.Price}");
            }

            Console.WriteLine("8. Count the no. of products belong to Tablets");

            var countTablets = from p in products
                               where p.Catagory.Name == "Tablets"
                               select p;
            Console.WriteLine(countTablets.Count());

            Console.WriteLine("9. Show which catagory has costly product");

            var CostlyProduct = from p in products
                                orderby p.Price descending
                                select p.Catagory.Name;
            Console.WriteLine(CostlyProduct.First());


            Console.WriteLine("10. Show which catagory has less products");

            var countInCategory = from p in products
                                  group p by p.Catagory into cat
                                  orderby cat.Count() ascending
                                  select cat.Key.Name;

            Console.WriteLine(countInCategory.First());


            Console.WriteLine("11. Extract the Product Details based on the catagory and show as below"); 

            //Laptops
            //    Dell XPS 13

            //    HP 430
            //Mobiles
            //    IPhone 6

            //    Galaxy S6
            //Tablets
            //    IPad Pro

            var printCategory = from p in products
                                group p by p.Catagory into cat
                                orderby cat.Count() descending
                                select cat.Key.Name;

            foreach (var product in printCategory)
            {
                Console.WriteLine($"{product}");
                var printProducts = from p in products
                                    where p.Catagory.Name == product
                                    select p.Name;
                foreach (var item in printProducts)
                {
                    Console.WriteLine($"\t{item}");
                }
            }

            Console.WriteLine("12. Extract the Product count based on the catagory and show as below"); 

            //Laptops: 2
            //Mobiles: 2
            //Tablets: 1

            var productCount = from p in products
                                group p by p.Catagory into cat
                                orderby cat.Count() descending
                                select cat;

            foreach(var item in productCount)
            {
                Console.WriteLine($"{item.Key.Name} : {item.Count()}");
            }
        }

    }
    class ProductsDB
    {
        public static List<Product> GetProducts()
        {
            Catagory cat1 = new Catagory { CatagoryID=101, Name="Laptops" };
            Catagory cat2 = new Catagory { CatagoryID = 201, Name = "Mobiles" };
            Catagory cat3 = new Catagory { CatagoryID = 301, Name = "Tablets" };

            Product p1 = new Product { ProductID=1, Name="Dell XPS 13", Catagory=cat1, Price=90000 };
            Product p2 = new Product { ProductID = 2, Name = "HP 430", Catagory = cat1, Price = 50000 };
            Product p3 = new Product { ProductID = 3, Name = "IPhone 6", Catagory = cat2, Price = 80000 };
            Product p4 = new Product { ProductID = 4, Name = "Galaxy S6", Catagory = cat2, Price = 74000 };
            Product p5 = new Product { ProductID = 5, Name = "IPad Pro", Catagory = cat3, Price = 44000 };

            cat1.Products.Add(p1);
            cat1.Products.Add(p2);
            cat2.Products.Add(p3);
            cat2.Products.Add(p4);
            cat3.Products.Add(p5);

            List<Product> products = new List<Product>();
            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);
            products.Add(p5);

            return products;
        }
    }
    class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Catagory Catagory { get; set; }
    }
    class Catagory
    {
        public int CatagoryID { get; set; }
        public string Name { get; set; }
        public List<Product> Products = new List<Product>();
    }
}