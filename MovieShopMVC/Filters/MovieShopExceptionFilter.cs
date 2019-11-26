using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShopMVC.Filters
{
    public class MovieShopExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            filterContext.Result = new ViewResult
            {
                ViewName = View,
                MasterName = Master,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };

            var dateExceptionHappened = DateTime.Now.TimeOfDay.ToString();
            //set breakpoint on the following line to see what the requested path and query is
            var pathAndQuery = filterContext.HttpContext.Request.Path + filterContext.HttpContext.Request.QueryString;
            // throw new FileNotFoundException();
            // log the error using logging Frameworks such as nLog, SeriLog, log4net etc.
            // download nLog
            // need logic for logging.
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            Logger logger = LogManager.GetLogger("MovieShopExceptionLogger");
            logger.Info("An Exception");
            // logger.Error(filterContext.Exception, "There is an exception");

            base.OnException(filterContext);
        }
    }
}