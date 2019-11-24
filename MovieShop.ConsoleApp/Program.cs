using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Entities;
using MovieShop.Services;

namespace MovieShop.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieService movie = new MovieService();
            List<Movie> myMovie = movie.GetMoviesByGenreId(2).ToList();
            foreach (var item in myMovie)
            {
                Console.WriteLine(item.Id + " " + item.Title);
            }
            Console.Read();
        }
    }
}
