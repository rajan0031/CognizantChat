

namespace Server.Models
{

    public class Message
    {

        public int Id { get; set; }

        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string? TextMessage { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }

}