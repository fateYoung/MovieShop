using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Entities;

namespace MovieShop.Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<User> GetUserByName(string FirstName, string LastName)
        {
            var users = _dbContext.Users.Where(u => u.FirstName == FirstName && u.LastName == LastName).ToList();
            return users;
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetUserByName(string FirstName, string LastName);
    }
}
