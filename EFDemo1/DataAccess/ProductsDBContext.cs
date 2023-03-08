using EFDemo1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo1.DataAccess
{
    public class ProductsDBContext: DbContext
    {
        // Configure DB 
        public ProductsDBContext() : base("name=default")
        {

        }

        // Configure DB Tables
        public DbSet<Product> Products { get; set; }
    }
}
