using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Data;
using MovieShop.Entities;

namespace MovieShop.Services
{
    public class CastService : ICastService
    {
        CastRepository _castRepository;
        public CastService()
        {
            _castRepository = new CastRepository(new MovieShopDbContext());
        }
    }

    public interface ICastService
    {

    }
}
