using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShop.Services;
using MovieShop.Entities;

namespace MovieShopMVC.Controllers
{
    [RoutePrefix("Movies")]
    public class MoviesController : Controller
    {
        private MovieService _movieService;
        public MoviesController()
        {
            _movieService = new MovieService();
        }

        public ActionResult TopRateMovies()
        {
            var movies = _movieService.GetTopRatedMovies();
            return View("Index", movies);
        }

        // GET: Movies
        public ActionResult TopMovies()
        {
            var movies = _movieService.GetTopGrossingMovies();
            return View("Index", movies);
        }

        [Route("Genre/{id}")]
        public ActionResult Index(int id)
        {
            var movies = _movieService.GetMoviesByGenreId(id);
            return View(movies);
        }
    }
}