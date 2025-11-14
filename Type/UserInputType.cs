using GraphQL.Types;
using Server.Type;


namespace Server.Type
{

    public class UserInputType : InputObjectGraphType
    {

        public UserInputType()
        {

            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("email");
            Field<StringGraphType>("password");
            Field<StringGraphType>("about");

        }

    }

}