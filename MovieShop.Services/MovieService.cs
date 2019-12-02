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
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _movieRepository.GetAll();
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

        public IEnumerable<Movie> GetTop20FavoritedMovies()
        {
            return _movieRepository.GetTopFavoritedMovies();
        }

        public IEnumerable<Movie> GetTop20PurchasedMovies()
        {
            return _movieRepository.GetTopPurchasedMovies();
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

    public class MovieService2 : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService2(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            throw new NotImplementedException();
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

        public IEnumerable<Movie> GetTop20FavoritedMovies()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetTop20PurchasedMovies()
        {
            throw new NotImplementedException();
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
        IEnumerable<Movie> GetTop20PurchasedMovies();
        IEnumerable<Movie> GetTop20FavoritedMovies();
        IEnumerable<Movie> GetAllMovies();
    }
}
