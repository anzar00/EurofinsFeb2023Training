using Humanizer;
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

        //private IArticlesRepository Arepo = null;
        //private ICategoryRepository Crepo = null;
        //private IArticlesManager articlesManager = null;
        //private ICategoriesManager categoriesManager = null;

        //public ArticlesController()
        //{
        //    Arepo = new ArticlesRepository();
        //    Crepo = new CategoryRepository();
        //    articlesManager = new ArticlesManager(Arepo);
        //    categoriesManager = new CategoryManager(Crepo);
        //}

        //IOC
        private IArticlesManager articlesManager = null;
        private ICategoriesManager categoriesManager = null;

        public ArticlesController(IArticlesManager articlesManager, ICategoriesManager categoriesManager)
        {
            this.articlesManager = articlesManager;
            this.categoriesManager = categoriesManager;
        }
        

        public ActionResult Index()
        {
            var articlesForBrowse = from a in articlesManager.GetArticlesForBrowse()
                                    select new ArticlesForBrowseViewModel
                                    {
                                        Title = a.Title,
                                        Url = a.Url,
                                        Description = a.Description,
                                        CategoryName = a.Category.Name,
                                        Submiter = a.Submiter,
                                        CreatedOn = a.DateSubmitted.Humanize(false)
                                    };
            return View(articlesForBrowse);
        }

        [HttpPost]
        public ActionResult Index(string searchTerm = null)
        {
            var articlesForBrowse = from a in articlesManager.GetArticlesForBrowse()
                                    select new ArticlesForBrowseViewModel
                                    {
                                        Title = a.Title,
                                        Url = a.Url,
                                        Description = a.Description,
                                        CategoryName = a.Category.Name,
                                        Submiter = a.Submiter,
                                        CreatedOn = a.DateSubmitted.Humanize(false)
                                    };

            if(searchTerm != null)
            {
                var filteredArticles = articlesForBrowse.Where(a => a.Title.Contains(searchTerm) ||
                                                               a.Description.Contains(searchTerm) ||
                                                               a.CategoryName.Contains(searchTerm) ||
                                                               a.Url.Contains(searchTerm) ||
                                                               a.Submiter.Contains(searchTerm));
                return View(filteredArticles);
            }
            return View(articlesForBrowse);

        }

        [HttpGet]
        [Authorize]
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
        [Authorize(Roles = "admin")]
        public ActionResult ReviewArticles()
        {
            var articlesForReview = from a in articlesManager.GetArticlesForReview()
                                    select new ReviewArticlesViewModel
                                    {
                                        Id = a.Id,
                                        Title = a.Title,
                                        Url = a.Url,
                                        Category = a.Category.Name,
                                        Submiter = a.Submiter,
                                        WhenSubmitted = a.DateSubmitted.Humanize(false)
                                    };
            return View(articlesForReview);
        }
        [Authorize(Roles = "admin")]
        public ActionResult Accept(List<int> articleIds)
        {
            articlesManager.ApproveArticle(articleIds);
            TempData["Message"] = $"{articleIds.Count()} articles approved and added successfuly.";
            //Send mail to the user 
            return RedirectToAction("ReviewArticles");
        }
        [Authorize(Roles = "admin")]
        public ActionResult Reject(List<int> articleIds)
        {
            articlesManager.RejectArticle(articleIds);
            TempData["Message"] = $"{articleIds.Count()} articles rejected successfuly.";
            //Send mail to the user
            return RedirectToAction("ReviewArticles");
        }
    }
}