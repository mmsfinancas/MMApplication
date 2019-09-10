using MMDomain.User;
using MMInfra.Config;
using MMInfra.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMInfra.Collections
{
    public class UserResetPasswordDB: DatabaseConfig<UserResetPassword>, IUserResetPasswordDB
    {
        public UserResetPasswordDB()
        {
            this.setCollection("UserResetPassword");
        }
        public void Post(UserResetPassword userResetPassword)
        {
            this.Insert(userResetPassword);
        }
    }
}
