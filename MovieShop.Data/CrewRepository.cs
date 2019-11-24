using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Entities;

namespace MovieShop.Data
{
    public class CrewRepository : Repository<Crew>, ICrewRepository
    {
        public CrewRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }
    }

    public interface ICrewRepository : IRepository<Crew>
    {

    }
}
