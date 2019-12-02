using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Entities;

namespace MovieShop.Data
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Movie> GetMovieByGenreId(int genreId)
        {
            var movies = _dbContext.Movies.Where(m => m.Genres.Any(g => g.Id == genreId)).ToList();
            return movies;
        }

        public IEnumerable<Movie> GetTopFavoritedMovies()
        {
            var movieFavorited = _dbContext.Favorites.GroupBy(f => f.MovieId)
                                                     .Select(mf => new { MovieId = mf.Key, Count = mf.Count() })
                                                     .OrderByDescending(mf1 => mf1.Count).Take(20).ToList();
            var movies = new List<Movie>();
            foreach (var item in movieFavorited)
            {
                movies.Add(_dbContext.Movies.Where(m => m.Id == item.MovieId).FirstOrDefault());
                movies.Where(m => m.Id == item.MovieId).FirstOrDefault().FavoritedCount = item.Count;
            }

            return movies.Where(m => m.FavoritedCount != null);
        }

        public IEnumerable<Movie> GetTopPurchasedMovies()
        {
            var moviePurchased = _dbContext.Purchases.GroupBy(p => p.MovieId)
                                                     .Select(mp => new { MovieId = mp.Key, Count = mp.Count() })
                                                     .OrderByDescending(mp1 => mp1.Count).Take(20).ToList();
            var movies = new List<Movie>();
            foreach (var item in moviePurchased)
            {
                movies.Add(_dbContext.Movies.Where(m => m.Id == item.MovieId).FirstOrDefault());
                movies.Where(m => m.Id == item.MovieId).FirstOrDefault().PurchasedCount = item.Count;
            }

            return movies.Where(m => m.PurchasedCount != null);
        }

        public IEnumerable<Movie> GetTopRatingMovies()
        {
            //var movieReview = (from movie in _dbContext.Movies
            //                   join review in _dbContext.Reviews
            //                   on movie.Id equals review.MovieId
            //                   group review by movie.Id into mr
            //                   select new
            //                   {
            //                       MovieId = mr.Key,
            //                       AvgReview = mr.Average(r => r.Rating)
            //                   }).OrderByDescending(rm => rm.AvgReview).Take(20).Select(rr => rr.MovieId).ToList();
            //var topRatedMovie = _dbContext.Movies.Where(m => movieReview.Contains(m.Id)).ToList();
            //return topRatedMovie;
            var movieReview = from r in _dbContext.Reviews
                               group r by r.MovieId into mr
                               select new
                               {
                                   MovieID = mr.Key,
                                   AvgReview = mr.Average(r => r.Rating)
                               };
            var movieList = new List<Movie>();

            foreach (var mvRating in movieReview)
            {
                movieList.Add(_dbContext.Movies.Where(m => m.Id == mvRating.MovieID).FirstOrDefault());
                movieList.Where(m => m.Id == mvRating.MovieID).FirstOrDefault().AvgRating = mvRating.AvgReview;
            }

            var topMovieRating = movieList.OrderByDescending(m => m.AvgRating).Take(20).Where(r => r.AvgRating != null).ToList();

            return topMovieRating;
        }

        public IEnumerable<Movie> GetTopRevenueMovies()
        {
            var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(20).ToList();
            return movies;
        }
    }

    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetTopRevenueMovies();
        IEnumerable<Movie> GetMovieByGenreId(int genreId);
        IEnumerable<Movie> GetTopRatingMovies();
        IEnumerable<Movie> GetTopPurchasedMovies();
        IEnumerable<Movie> GetTopFavoritedMovies();
    }
}
