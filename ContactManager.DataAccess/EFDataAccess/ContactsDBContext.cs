using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ContactManager.DataAccess.EFDataAccess
{
    public partial class ContactsDBContext : DbContext
    {
        public ContactsDBContext()
            : base("name=ContactsDBContext")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Location)
                .IsUnicode(false);
        }
    }
}
