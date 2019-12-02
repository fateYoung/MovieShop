using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieShop.Entities;
using MovieShop.Services;

namespace MovieShop.API.Controllers
{
    [RoutePrefix("api/genres")]
    public class GenresController : ApiController
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllGenres()
        {
            var genres = _genreService.GetAllGenres();

            if (genres.Any())
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, genres);
                return ResponseMessage(response);
            }
            else
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "No genres found"));
            }
        }
    }
}
