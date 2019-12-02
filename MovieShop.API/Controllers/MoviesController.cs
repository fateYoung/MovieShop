using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MovieShop.API.DTO;
using MovieShop.Entities;
using MovieShop.Services;

namespace MovieShop.API.Controllers
{
    [RoutePrefix("api/movies")]
    public class MoviesController : ApiController
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [Route("topmovies")]
        public IHttpActionResult GetTopRevenueMovies()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieDTO>();
            });
            configuration.AssertConfigurationIsValid();

            var mapper = configuration.CreateMapper();


            var movies = _movieService.GetTopGrossingMovies();
            var moviesDTO = new List<MovieDTO>();

            foreach (var movie in movies)
            {
                var movieDTO = mapper.Map<MovieDTO>(movie);
                moviesDTO.Add(movieDTO);
            }

            if (moviesDTO.Any())
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, moviesDTO);
                return ResponseMessage(response);
            }
            else
            {
                var response = Request.CreateResponse(HttpStatusCode.NotFound, "No movies found.");
                return ResponseMessage(response);
            }

        }
    }
}
