using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShop.Services;
using MovieShop.Entities;

namespace MovieShopMVC.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        // GET: Genre
        public PartialViewResult Index()
        {
            var genres = _genreService.GetAllGenres();
            return PartialView("GenresView", genres);
        }
    }
}