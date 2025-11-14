using GraphQL;
using GraphQL.Types;
using Server.Interfaces;
using Server.Type;
using Server.Models;


namespace Server.Mutation
{


    public class MessageMutation : ObjectGraphType
    {



        public MessageMutation(IMessageRepository messageRepository)
        {




            Field<MessageType>("addMessage")
                 .Arguments(new QueryArguments(
                     new QueryArgument<NonNullGraphType<MessageInputType>> { Name = "message" }
                 ))
                 .Resolve(context =>
                 {
                     var message = context.GetArgument<Message>("message");
                     return messageRepository.AddMessage(message);
                 });



        }





    }



}