using Server.Models;

namespace Server.interfaces
{

    public interface IUserRepository
    {

        public List<User> GetAllUser();
        public User AddUser(User user);



    }

}