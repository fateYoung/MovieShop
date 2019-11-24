using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Data;
using MovieShop.Entities;

namespace MovieShop.Services
{
    public class PurchaseService : IPurchaseService
    {
        PurchaseRepository _purchaseRepository;
        public PurchaseService()
        {
            _purchaseRepository = new PurchaseRepository(new MovieShopDbContext());
        }
    }

    public interface IPurchaseService
    {

    }
}
