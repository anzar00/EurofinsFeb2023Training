using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo1.Entities
{
    public class Product //POCO class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public string Brand { get; set; }   
        public string Country { get; set; }
        public virtual Category Category { get; set; } // Virtual for lazy loading also enable MARS in app.config
        public virtual List<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }

    [Table("tbl_categories")]

    public class Category
    {
        [Key]
        public int catid { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        [Column("desc", TypeName = "varchar")]
        public string Description { get; set; }
        [NotMapped]
        public int Profit { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();
    }

    

    abstract public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // For TPC
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }

    //[Table("Customers")]
    public class Customer : Person
    {
        public string CustomerType { get; set; }
        public int Discount { get; set; }
    }

    [Table("Suppliers")]
    public class Supplier : Person
    {
        public string GST { get; set; }
        public int Rating { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
        public Address Address { get; set; } = new Address();

    }

    [ComplexType]
    public class Address
    {
        public string Area { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }

    }

}
