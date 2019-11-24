using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Entities;
using MovieShop.Data;

namespace MovieShop.Services
{
    public class CrewService : ICrewService
    {
        CrewRepository _crewRepository;
        public CrewService()
        {
            _crewRepository = new CrewRepository(new MovieShopDbContext());
        }
    }

    public interface ICrewService
    {

    }
}
