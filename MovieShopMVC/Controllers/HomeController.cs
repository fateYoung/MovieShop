using MovieShopMVC.Filters;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShopMVC.Controllers
{
    [LogActionFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
                
        public ActionResult About()
        {
            int i = 0;
            int x = 1;
            int z = x / i;           
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}