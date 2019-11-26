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
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid) //Save to database only when model is valid
            {
                // redirect to indexf action method
                return RedirectToAction("TopMovies");
            }
            return View();
        }
    }
}