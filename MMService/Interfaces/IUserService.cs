using MMDomain.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMService.Interfaces
{
    public interface IUserService
    {
        void InsertUser(User user);
        Task<List<User>> GetUsers();
        Task<string> ResetPassword(string userMail);
    }
}
