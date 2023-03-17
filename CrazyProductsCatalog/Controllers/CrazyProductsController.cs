using CrazyProductsCatalog.Models.Data;
using CrazyProductsCatalog.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;

namespace CrazyProductsCatalog.Controllers
{
    public class CrazyProductsController : ApiController
    {
        private CrazyProductsDBContext db = new CrazyProductsDBContext();

        // Design and implement the End-Points
        // URI
        // Resource : Products
        // Action : GET
        // URI : .../api/CrazyProducts
        //[HttpGet]

        [EnableQuery]
        public IHttpActionResult GetProducts()
        {
            // Get products from the back-end
            // Return the products
            return Ok(db.CrazyProducts.AsQueryable());
        }

        // POST .../api/CrazyProducts
        public IHttpActionResult Post(CrazyProduct product)
        {
           if (!ModelState.IsValid)
           {
                return BadRequest("Invalid Input");
           }
           db.CrazyProducts.Add(product);
           db.SaveChanges();
           return Created($"api/crazyproducts/{product.Id}", product);
        }

        // POST .../api/async/CrazyProducts
        public async Task<IHttpActionResult> PostAsync(CrazyProduct product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Input");
            }
            db.CrazyProducts.Add(product);
            await db.SaveChangesAsync();
            return Created($"api/crazyproducts/{product.Id}", product);
        }
        [Route("api/v2/crazyproducts")]
        // POST .../api/async/CrazyProducts
        public IHttpActionResult Postv2(CrazyProduct product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Input");
            }
            db.CrazyProducts.Add(product);
            db.SaveChangesAsync();
            return Created($"api/v2/crazyproducts/{product.Id}", product);
        }

        // DELETE .../api/crazyproducts/id

        public IHttpActionResult Delete(int id)
        {
            var productToDel = db.CrazyProducts.Find(id);
            if(productToDel == null)
            {
                return NotFound();
            }
            db.CrazyProducts.Remove(productToDel);
            db.SaveChanges();
            return Ok();
        }
        // PUT .../api/crazyproducts
        public IHttpActionResult Put(CrazyProduct product)
        {
            // Validate
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Input");
            }
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }

        //Other endpoints
        //public List<CrazyProduct> GetProducts()
        //{
        //    // Get products from the back-end
        //    // Return the products
        //    return db.CrazyProducts.ToList();
        //}

        ////GET .../api/crazyproducts/1
        //public IHttpActionResult GetCrazyProduct(int id)
        //{
        //    var product = db.CrazyProducts.Find(id);
        //    if (product == null) //not found
        //    {
        //        // return 404
        //        return NotFound();
        //    }
        //    // if found, return data + product
        //    return Ok(product);
        //}

        ////GET .../api/crazyproducts/category/mobiles
        //[Route("api/crazyproducts/category/{category}")]
        ////[HttpGet]
        //public IHttpActionResult GetCrazyProductsByCategory(string category)
        //{
        //    var products = db.CrazyProducts.Where(p => p.Category == category).ToList();
        //    if (products == null || products.Count == 0) //not found
        //    {
        //        return NotFound(); //return 404
        //    }
        //    // if found, return data + product
        //    return Ok(products);
        //}

        ////return all products based on country

        ////GET .../api/crazyproducts/country/india
        //[Route("api/crazyproducts/country/{country}")]

        //public IHttpActionResult GetCrazyProductsByCountry(string country)
        //{
        //    var products = db.CrazyProducts.Where(p => p.Country == country).ToList();
        //    if (products == null || products.Count == 0) //not found
        //    {
        //        return NotFound(); //return 404
        //    }
        //    // if found, return data + product
        //    return Ok(products);
        //}

        ////return all products based on brand

        ////GET .../api/crazyproducts/brand/Samsung
        //[Route("api/crazyproducts/brand/{brand}")]
        //public IHttpActionResult GetCrazyProductsByBrand(string brand)
        //{
        //    var products = db.CrazyProducts.Where(p => p.Brand == brand).ToList();
        //    if (products == null || products.Count == 0) //not found
        //    {
        //        return NotFound(); //return 404
        //    }
        //    // if found, return data + product
        //    return Ok(products);
        //}

        ////return expensive product

        ////GET .../api/crazyproducts/expensive

        //[Route("api/crazyproducts/expensive")]
        //public IHttpActionResult GetExpensive()
        //{
        //    var product = db.CrazyProducts.OrderByDescending(p => p.Price).First();
        //    if (product == null) //not found
        //    {
        //        return NotFound(); //return 404
        //    }
        //    // if found, return data + product
        //    return Ok(product);
        //}


        ////return cheapest product

        ////GET .../api/crazyproducts/cheapest

        //[Route("api/crazyproducts/cheapest")]
        //public IHttpActionResult GetCheapest()
        //{
        //    var product = db.CrazyProducts.OrderBy(p => p.Price).First();
        //    if (product == null) //not found
        //    {
        //        return NotFound(); //return 404
        //    }
        //    // if found, return data + product
        //    return Ok(product);
        //}

        ////return all products between min price and max price range

        ////GET .../api/crazyproducts/inrange
        
        //[Route("api/crazyproducts/inrange")]
        //public IHttpActionResult GetCrazyProductsInRange(int min, int max)
        //{
        //    var products = db.CrazyProducts.Where(p => p.Price>=min & p.Price<=max).ToList();

        //    if (products == null || products.Count == 0) //not found
        //    {
        //        return NotFound(); //return 404
        //    }
        //    // if found, return data + product
        //    return Ok(products);
        //}


        ////return product based on name

        ////GET .../api/crazyproducts/name/S23
        //[Route("api/crazyproducts/name/{name}")]
        //public IHttpActionResult GetCrazyProductsByName(string name)
        //{
        //    var products = db.CrazyProducts.Where(p => p.Name == name).ToList();
        //    if (products == null || products.Count == 0) //not found
        //    {
        //        return NotFound(); //return 404
        //    }
        //    // if found, return data + product
        //    return Ok(products);
        //}
    }
}
