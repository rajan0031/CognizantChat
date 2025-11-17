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

            // this is for login the user 
            Field<UserType>("loginuser")
     .Arguments(new QueryArguments(
         new QueryArgument<StringGraphType> { Name = "email" },
         new QueryArgument<StringGraphType> { Name = "password" }
     ))
     .Resolve(context =>
     {
         var email = context.GetArgument<string>("email");
         var password = context.GetArgument<string>("password");

         return userRepository.LoginUser(email, password);
     });



        }





    }



}