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
        // Do Not Do This - Inject with IOC instead

        // GET: Categories

        //private ICategoryRepository repo = null;
        //CategoryManager categoriesManager = null;

        //public CategoriesController() 
        //{
        //    repo = new CategoryRepository();
        //    categoriesManager = new CategoryManager(repo);
        //}

        //IOC
        private ICategoriesManager categoriesManager = null;

        public CategoriesController(ICategoriesManager categoriesManager)
        {
            this.categoriesManager = categoriesManager;
        }
        public ActionResult Index()
        {
            var categoryList = categoriesManager.ListCategories();
            return View(categoryList);
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
            
            categoriesManager.AddCategory(category);

            TempData["Message"] = $"Category {category.Name} added successfully...";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            // Fetch category details based on id and and send to view for editing

            var category = categoriesManager.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category editedCategory)
        {
            // Validate
            if (!ModelState.IsValid)
            {
                return View(editedCategory);
            }
            
            // Update in the DB 
            categoriesManager.EditCategory(editedCategory);

            //return View("Index", categoriesManager.ListCategories());

            // Redirect to Index
            TempData["Message"] = $"Category edited successfully...";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var catToDelete = categoriesManager.GetCategoryById(id);
            return View(catToDelete);
        }

        public ActionResult ConfirmDelete(int id)
        {
            categoriesManager.DeleteCategory(id);
            // Redirect to Index
            TempData["Message"] = $"Category {id} deleted successfully...";
            return RedirectToAction("Index");
        }



    }
}