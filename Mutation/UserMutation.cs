using GraphQL;
using GraphQL.Types;
using Server.Interfaces;
using Server.Type;
using Server.Models;


namespace Server.Mutation
{


    public class UserMutation : ObjectGraphType
    {



        public UserMutation(IUserRepository userRepository)
        {




            Field<UserType>("adduser").Arguments(new QueryArguments(new QueryArgument<UserInputType> { Name = "user" })).Resolve(context =>
           {
               var user = context.GetArgument<User>("user");

               return userRepository.AddUser(user);

           });



        }





    }



}