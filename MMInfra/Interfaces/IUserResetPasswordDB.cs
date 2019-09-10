using MMDomain.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMInfra.Interfaces
{
    public interface IUserResetPasswordDB
    {
        void Post(UserResetPassword userResetPassword);
    }
}
