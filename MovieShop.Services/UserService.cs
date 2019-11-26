using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Data;
using MovieShop.Entities;

namespace MovieShop.Services
{
    public class UserService : IUserService
    {
        UserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository(new MovieShopDbContext());
        }

        public void InsertNewUser(User user)
        {
            _userRepository.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public IEnumerable<User> GetUserByFullName(string FirstName, string LastName)
        {
            return _userRepository.GetUserByName(FirstName, LastName);
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.Get(u => u.Email == email);
        }
    }

    public interface IUserService
    {
        IEnumerable<User> GetUserByFullName(string FirstName, string LastName);
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        User GetUserByEmail(string email);
    }
}
