using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeHubPortal.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // /Home/Hello
        public ActionResult Hello()
        {
            string greeting = "Hello, welocome to MVC!";
            ViewBag.Message = greeting; //Used ofr passing simple, small amount of data.
            //ViewData["Message"] = greeting;
            //TempData["Message"] = greeting; //Used primarily for notifications
            return View();
        }
    }
}