using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShop.Entities;

namespace MovieShopMVC.ViewModel
{
    public class PurchaseFavoriteViewModel
    {
        public List<Movie> PurchasesList { get; set; }
        public List<Movie> FavoritesList { get; set; }
    }
}