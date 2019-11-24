using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Data;
using MovieShop.Entities;

namespace MovieShop.Services
{
    public class GenreService : IGenreService
    {
        GenreRepository _genreRepository;
        public GenreService()
        {
            _genreRepository = new GenreRepository(new MovieShopDbContext());
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _genreRepository.GetAll().OrderBy(g => g.Name).ToList();
        }
    }

    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
    }
}
