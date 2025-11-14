using GraphQL.Types;


namespace Server.Query
{


    public class RootQuery : ObjectGraphType
    {



        public RootQuery()
        {

            Field<UserQuery>("userQuery").Resolve(context => new { });
            Field<MessageQuery>("messageQuery").Resolve(context => new { });


        }

    }




}