using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Entities;
using MovieShop.Data;

namespace MovieShop.Services
{
    public class MovieService : IMovieService
    {
        MovieRepository _movieRepository;
        public MovieService()
        {
            _movieRepository = new MovieRepository(new MovieShopDbContext());
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetById(id);
        }

        public Movie GetMovieByName(string name)
        {
            return _movieRepository.Get(m => m.Title == name);
        }

        public IEnumerable<Movie> GetMoviesByGenreId(int genreId)
        {
            return _movieRepository.GetMovieByGenreId(genreId);
        }

        public IEnumerable<Movie> GetTopGrossingMovies()
        {
            return _movieRepository.GetTopRevenueMovies();
        }

        public IEnumerable<Movie> GetTopRatedMovies()
        {
            return _movieRepository.GetTopRatingMovies();
        }
    }

    public interface IMovieService
    {
        IEnumerable<Movie> GetTopGrossingMovies();
        Movie GetMovieById(int id);
        Movie GetMovieByName(string name);
        IEnumerable<Movie> GetMoviesByGenreId(int genreId);
        IEnumerable<Movie> GetTopRatedMovies();
    }
}
