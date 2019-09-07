using MMDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMInfra.Interfaces
{
    public interface IUserDB
    {
        Task<List<User>> Get();
        Task<List<User>> Get(string email);
        void Post(User user);
    }
}
