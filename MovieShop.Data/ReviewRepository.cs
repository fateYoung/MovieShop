using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Data;
using MovieShop.Entities;

namespace MovieShop.Data
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }
    }

    public interface IReviewRepository
    {

    }
}
