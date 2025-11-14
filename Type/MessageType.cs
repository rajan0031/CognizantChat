using GraphQL.Types;
using Server.Models;


namespace Server.Type
{

    public class MessageType : ObjectGraphType<Message>
    {
        public MessageType()
        {
            Field(u => u.Id);
            Field(u => u.SenderId);
            Field(u => u.ReceiverId);
            Field(u => u.TextMessage);
            Field(u => u.CreatedAt);
        }
    }

}