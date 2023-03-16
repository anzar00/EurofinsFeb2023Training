using CrazyProductsCatalog.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrazyProductsCatalog.Models.Data
{
    public class CrazyProductsDBContext : DbContext
    {
        public CrazyProductsDBContext() : base("name=DefautlConnection")
        {

        }

        public DbSet<CrazyProduct> CrazyProducts { get; set;}
    }
}