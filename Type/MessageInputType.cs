using GraphQL.Types;
using Server.Type;


namespace Server.Type
{

    public class MessageInputType : InputObjectGraphType
    {

        public MessageInputType()
        {

            Field<IntGraphType>("id");
            Field<IntGraphType>("senderid");
            Field<IntGraphType>("receiverid");
            Field<StringGraphType>("textmessage");
         

        }

    }

}