using EFDemo1.DataAccess;
using EFDemo1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Log();

            // Want to save products info into database
            // EF Code First approach

            //Save();

            // Want to read products info from database
            // EF Code First approach

            //Read();

            // Wamt to remove products info from database
            // EF Code First approach

            //Delete();

            // Want to update the price of product id 2 with 2000;
            //Update();

            //Add new category with new product

            //AddNewCatWithNewProd();

            //Add new product into Mobiles Category

            //NewProductInExistingCategory();

            //Display Product Name and Category Name

            //DisplayProductNameAndCategory();

            //Get all products that belong to Mobiles category
            //GetAllMobiles();

            //AddPeople();

            //ProductsDBContext db = new ProductsDBContext();
            //db.Database.Log = Console.WriteLine;

            ////Get all customers
            //var allCustomers = db.People.OfType<Customer>().ToList();

            //foreach (var c in allCustomers)
            //{
            //    Console.WriteLine(c.Name);
            //}

            ProductsDBContext db = new ProductsDBContext();
            db.Database.Log = Console.WriteLine;

            string sqlUpdate = "UPDATE Products SET rate = rate + 1000";
            db.Database.ExecuteSqlCommand(sqlUpdate);
            Console.WriteLine($"{sqlUpdate} done");

        }

        private static void AddPeople()
        {
            ProductsDBContext db = new ProductsDBContext();
            db.Database.Log = Console.WriteLine;

            // Add new customer
            var c = new Customer
            {
                PersonID = 333,
                Name = "Raj",
                Mobile = "1234567890",
                Email = "raj@gmail.com",
                CustomerType = "Premium",
                Discount = 12,
                Location = "Mumbai",
            };
            db.People.Add(c);

            // Add new supplier

            var s = new Supplier
            {
                PersonID = 444,
                Name = "SS",
                GST= "1234567890",
                Rating = 8,
                Email = "ss@email.com",
                Location = "Mumbai",
                Mobile = "1234567890",
            };

            db.People.Add(s);

            db.SaveChanges();
        }

        private static void GetAllMobiles()
        {
            ProductsDBContext db = new ProductsDBContext();
            db.Database.Log = Console.WriteLine;
            var mobiles = (from c in db.Categories
                           where c.Name == "Mobiles"
                           select c.Products).FirstOrDefault();

            foreach (var m in mobiles)
            {
                Console.WriteLine(m.Name);
            }
        }

        private static void DisplayProductNameAndCategory()
        {
            ProductsDBContext db = new ProductsDBContext();
            db.Database.Log = Console.WriteLine;
            var names = from p in db.Products//.Include("Category") //Eager Loading
                        select p;

            foreach (var n in names)
            {
                //Check if category name is null, if yes do not print, else print
                if (n.Category != null)
                    Console.WriteLine($"{n.Name}\t{n.Rate}\t {n.Category.Name}");
            }
        }

        private static void NewProductInExistingCategory()
        {
            ProductsDBContext db = new ProductsDBContext();
            db.Database.Log = Console.WriteLine;
            var mobiles = (from c in db.Categories
                           where c.Name == "Mobiles"
                           select c).FirstOrDefault();

            var p = new Product { Name = "Galaxy S23", Rate = 175000, Brand = "Samsung", Country = "India", Category = mobiles };

            db.Products.Add(p);
            db.SaveChanges();
            Console.WriteLine("Product Added");
        }

        private static void AddNewCatWithNewProd()
        {
            var cat = new Category { Name = "Mobiles" };
            var p = new Product { Name = "I Phone X", Rate = 75000, Brand = "Apple", Country = "India", Category = cat };

            ProductsDBContext db = new ProductsDBContext();
            db.Products.Add(p);
            db.SaveChanges();
        }

        private static void Log()
        {
            ProductsDBContext db = new ProductsDBContext();

            db.Database.Log = Console.WriteLine;

            //LINQ to Entities
            var products = from p in db.Products
                           select p;
            foreach (var p in products)
            {
                Console.WriteLine(p.Id + " " + p.Name + " " + p.Description + " " + p.Rate);
            }
        }

        private static void Update()
        {
            ProductsDBContext db = new ProductsDBContext();
            var productToUpdate = db.Products.Find(2);
            if (productToUpdate == null)
            {
                Console.WriteLine("Product not found");
            }
            else
            {
                productToUpdate.Rate += 2000;
                Console.WriteLine("Done");
            }
            db.SaveChanges();
        }

        private static void Delete()
        {
            ProductsDBContext db = new ProductsDBContext();
            // delete IPhoneX
            var producToDelete = (from p in db.Products
                                  where p.Name == "IPhoneX"
                                  select p).FirstOrDefault();

            if (producToDelete == null)
            {
                Console.WriteLine("Product not found");
            }
            else
            {
                db.Products.Remove(producToDelete);
                Console.WriteLine("Done");
            }
            db.SaveChanges();
        }

        private static void Read()
        {
            ProductsDBContext db = new ProductsDBContext();
            //get all products
            var products = from p in db.Products
                           select p;

            //display
            foreach (var p in products)
            {
                Console.WriteLine(p.Id + " " + p.Name + " " + p.Description + " " + p.Rate);
            }
        }

        private static void Save()
        {
            Product p = new Product { Name ="IPhnoneX", Description = "Expensive Phone", Rate = 75000 };
            ProductsDBContext db = new ProductsDBContext();
            db.Products.Add(p);
            db.SaveChanges();
            Console.WriteLine("Done");
        }
    }
}
