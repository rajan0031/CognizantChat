using Server.Models;

namespace Server.Interfaces
{

    public interface IMessageRepository
    {

        public Message AddMessage(Message message);

        public List<Message> GetAllMessage(int senderId,int receiverId);



    }

}