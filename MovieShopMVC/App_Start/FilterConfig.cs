﻿using MovieShopMVC.Filters;
using System.Web;
using System.Web.Mvc;

namespace MovieShopMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MovieShopExceptionFilter());
        }
    }
}
