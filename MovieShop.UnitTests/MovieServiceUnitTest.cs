using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieShop.Data;
using MovieShop.Entities;
using MovieShop.Services;
using Moq;

namespace MovieShop.UnitTests
{
    [TestClass]
    public class MovieServiceUnitTest
    {
        private readonly IMovieService _movieService;
        private readonly Mock<IMovieRepository> _mockMovieRepository;
        private List<Genre> _genres;
        private List<Movie> _movies;
        public MovieServiceUnitTest()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _movieService = new MovieService(_mockMovieRepository.Object);
            /*
             *Arrange: Initializes objects, creates mocks with arguments that are passed to the method
    under test and adds expectations.
    */
        }

        /// <summary>
        ///     Triggered before every test case.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange
            _genres = new List<Genre>
                      {
                          new Genre {Id = 1, Name = "Action"},
                          new Genre {Id = 2, Name = "Crime"},
                          new Genre {Id = 3, Name = "Drama"}
                      };
            _movies = new List<Movie>
                      {
                          new Movie
                          {
                              Id = 1,
                              Title = "TestMovie1",
                              Budget = 25000,
                              Genres = _genres.Where(g => g.Id == 1 || g.Id == 2).ToList()
                          },
                          new Movie
                          {
                              Id = 2,
                              Title = "TestMovie2",
                              Budget = 25000,
                              Genres = _genres.Where(g => g.Id == 1 || g.Id == 2).ToList()
                          },
                          new Movie
                          {
                              Id = 3,
                              Title = "TestMovie3",
                              Budget = 25000,
                              Genres = _genres.Where(g => g.Id == 2 || g.Id == 3).ToList()
                          },
                          new Movie
                          {
                              Id = 4,
                              Title = "TestMovie4",
                              Budget = 25000,
                              Genres = _genres.Where(g => g.Id == 1 || g.Id == 3).ToList()
                          },
                          new Movie
                          {
                              Id = 5,
                              Title = "TestMovie5",
                              Budget = 25000,
                              Genres = _genres.Where(g => g.Id == 1).ToList()
                          }
                      };
            _mockMovieRepository.Setup(m => m.GetTopRevenueMovies()).Returns(_movies);
            _mockMovieRepository.Setup(mo => mo.GetById(It.IsAny<int>()))
                                .Returns((int m) => _movies.FirstOrDefault(x => x.Id == m));
        }

        [TestMethod]
        public void TestTopMoviesFromFakeData()
        {
            //Act: Invokes the method or property under test with the arranged parameters.
            var movies = _movieService.GetTopGrossingMovies();

            /*    
                Assert: Verifies that the action of the method under test behaves as expected.
            */
            Assert.AreEqual(5, movies.Count());
            Assert.IsNotNull(movies);
        }
    }

}
