using GraphQL.Types;
using Server.Interfaces;
using Server.Models;
using Server.Type;
using GraphQL;


namespace Server.Query
{


    public class MessageQuery : ObjectGraphType
    {


        public MessageQuery(IMessageRepository messageRepository)
        {


            Field<ListGraphType<MessageType>>("getAllMessage")
                .Arguments(new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "senderId" },
                    new QueryArgument<IntGraphType> { Name = "receiverId" }
                ))
                .Resolve(context =>
                {
                    var senderId = context.GetArgument<int>("senderId");
                    var receiverId = context.GetArgument<int>("receiverId");
                    return messageRepository.GetAllMessage(senderId, receiverId);
                });




        }

    }

}