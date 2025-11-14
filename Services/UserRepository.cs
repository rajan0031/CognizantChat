using Microsoft.EntityFrameworkCore;
using Server.interfaces;
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
            dbcontext.Users.Add(user);
            dbcontext.SaveChanges();
            return user;
        }

        public List<User> GetAllUser()
        {
           return dbcontext.Users.ToList();
        }
    }

}