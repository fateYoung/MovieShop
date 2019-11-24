using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Entities;

namespace MovieShop.Data
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieShopDbContext dbContext) :  base(dbContext)
        {
        }
    }

    public interface IGenreRepository : IRepository<Genre>
    {

    }
}
