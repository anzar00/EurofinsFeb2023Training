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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Map(c =>
            {
                c.MapInheritedProperties();
                c.ToTable("Customers");
            });

            modelBuilder.Entity<Supplier>().Map(s =>
            {
                s.MapInheritedProperties();
                s.ToTable("Suppliers");
            });

            // for stored procedures

            //modelBuilder.Entity<Customer>().MapToStoredProcedures();
            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
            //INSERT / UPDATE / DELETE
        }
    }
}
