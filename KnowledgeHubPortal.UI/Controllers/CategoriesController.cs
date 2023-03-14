using KnowledgeHubPortal.Data;
using KnowledgeHubPortal.Domain;
using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeHubPortal.UI.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            // Server Side Validation
            if (!ModelState.IsValid)
            {
                // Return View With Error Messages
                return View();
            }
            // Do Not Do This - Inject with IOC instead

            ICategoryRepository repo = new CategoryRepository();
            CategoryManager categoriesManager = new CategoryManager(repo);
            
            categoriesManager.AddCategory(category);
            
            return View();

        }
    }
}