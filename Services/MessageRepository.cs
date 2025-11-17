using Microsoft.EntityFrameworkCore;
using Server.Interfaces;
using Server.Models;
using Server.Data;

namespace Server.Services
{


    public class MessageRepository : IMessageRepository
    {

        private AppDbContext dbcontext;

        public MessageRepository(AppDbContext appDbContext)
        {
            this.dbcontext = appDbContext;

        }

        public Message AddMessage(Message message)
        {
            dbcontext.Messages.Add(message);
            dbcontext.SaveChanges();
            return message;
        }

        public List<Message> GetAllMessage(int senderId, int receiverId)
        {
            return dbcontext.Messages.Where(m=>m.SenderId==senderId && m.ReceiverId==receiverId).ToList();
        }
    }

}