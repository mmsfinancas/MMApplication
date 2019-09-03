using MMDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMInfra.Interfaces
{
    public interface IUserDB
    {
        Task<List<User>> Get();
        void Post(User user);
    }
}
