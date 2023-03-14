using KnowledgeHubPortal.Data;
using KnowledgeHubPortal.Domain;
using KnowledgeHubPortal.Domain.Data;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeHubPortal.UI.Controllers
{
    public class ArticlesController : Controller
    {
        // Do Not Do This - Inject with IOC instead

        // GET: Articles

        private IArticlesRepository Arepo = null;
        private ICategoryRepository Crepo = null;
        private IArticlesManager articlesManager = null;
        private ICategoriesManager categoriesManager = null;

        public ArticlesController()
        {
            Arepo = new ArticlesRepository();
            Crepo = new CategoryRepository();
            articlesManager = new ArticlesManager(Arepo);
            categoriesManager = new CategoryManager(Crepo);
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SubmitArticle()
        {
            //var categories = categoriesManager.ListCategories();
            var categories = from c in categoriesManager.ListCategories()
                             select new SelectListItem
                             {
                                 Text = c.Name,
                                 Value = c.CategoryId.ToString()
                             };
            ViewBag.CategoryId = categories;
            return View();
        }

        [HttpPost]
        public ActionResult SubmitArticle(ArticleSubmitViewModel articlevm)
        {
            // Server Side Validation
            if (!ModelState.IsValid)
            {
                return RedirectToAction("SubmitArticle");
            }

            // Convert ViewModel to DM 
            Article article = new Article();
            article.Title = articlevm.Title;
            article.Description = articlevm.Description;
            article.CategoryId = articlevm.CategoryId;
            article.Url = articlevm.Url;

            //Fill remaining properties
            article.IsApproved = false;
            article.DateSubmitted = DateTime.Now;
            if (User.Identity.IsAuthenticated)
                article.Submiter = User.Identity.Name;
            else
                article.Submiter = "Anonymous";

            //Submit to domain
            articlesManager.SubmitArticle(article);
            TempData["Message"] = $"Article - {article.Title} added successfully for review...";
            return RedirectToAction("Index");
        }
    }
}