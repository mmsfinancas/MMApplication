using MMDomain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMService.Interfaces
{
    public interface IUserService
    {
        void Post(User user);
        Task<List<User>> Get();
    }
}
