using GraphQL.Types;
using Server.Models;


namespace Server.Type
{

    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(u => u.Id);
            Field(u => u.Name);
            Field(u => u.Email);
            Field(u => u.Password);
            Field(u => u.About);
        }
    }

}