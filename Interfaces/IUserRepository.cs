using Server.Models;

namespace Server.Interfaces
{

    public interface IUserRepository
    {

        public List<User> GetAllUser();
        public User AddUser(User user);



    }

}