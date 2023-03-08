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
            Update();
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
