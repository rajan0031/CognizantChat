using Server.Models;

namespace Server.Interfaces
{

    public interface IUserRepository
    {

        public List<User> GetAllUser();
        public User AddUser(User user);

        public User LoginUser(string email,string password);



    }

}