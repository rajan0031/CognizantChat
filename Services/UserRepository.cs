using Microsoft.EntityFrameworkCore;
using Server.Interfaces;
using Server.Models;
using Server.Data;

namespace Server.Services
{


    public class UserRepository : IUserRepository
    {

        private AppDbContext dbcontext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.dbcontext = appDbContext;

        }


        public User AddUser(User user)
        {
            var email = user.Email;
            var result = dbcontext.Users.FirstOrDefault(u => u.Email == email);
            if (result != null)
            {
                return null;
            }
            dbcontext.Users.Add(user);
            dbcontext.SaveChanges();
            return user;
        }

        public List<User> GetAllUser()
        {
            return dbcontext.Users.ToList();
        }

        public User LoginUser(string email,string password)
        {
           

            var result = dbcontext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (result == null)
            {
                return null;
            }

            return result;
        }
    }

}