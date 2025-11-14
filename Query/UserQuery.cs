using GraphQL.Types;
using Server.interfaces;
using Server.Models;
using Server.Type;


namespace Server.Query
{


    public class UserQuery : ObjectGraphType
    {


        public UserQuery(IUserRepository userRepository)
        {


            Field<ListGraphType<UserType>>("getalluser").Resolve(context =>
            {
                return userRepository.GetAllUser();
            });

        }

    }

}