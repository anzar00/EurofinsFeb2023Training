using CrazyProductsCatalog.Models.Data;
using CrazyProductsCatalog.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrazyProductsCatalog.Controllers
{
    public class CrazyProductsController : ApiController
    {
        private CrazyProductsDBContext db = new CrazyProductsDBContext();

        // Design and implement the End-Points
        // URI
        // Resource : Products
        // Action : GET
        // URI : .../
        public List<CrazyProduct> GetProducts()
        {
            // Get products from the back-end
            // Return the products
            return db.CrazyProducts.ToList();
        }
    }
}
