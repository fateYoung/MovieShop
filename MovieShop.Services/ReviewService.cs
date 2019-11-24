using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Data;
using MovieShop.Entities;

namespace MovieShop.Services
{
    public class ReviewService : IReviewService
    {
        ReviewRepository _reviewRepository;
        public ReviewService()
        {
            _reviewRepository = new ReviewRepository(new MovieShopDbContext());
        }
    }

    public interface IReviewService
    {

    }
}
