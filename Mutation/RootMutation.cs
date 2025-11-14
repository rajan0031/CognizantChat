using GraphQL.Types;
using Server.Mutation;


namespace GraphQLProject.Mutation
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Field<UserMutation>("userMutation").Resolve(context => new { });
                       Field<MessageMutation>("messageMutation").Resolve(context => new { });



        }
    }
}
