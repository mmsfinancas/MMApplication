using MMDomain.User;
using MMInfra.Config;
using MMInfra.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMInfra.Collections
{
    public class UserDB : DatabaseConfig<User>, IUserDB
    {
        public UserDB()
        {
            this.setCollection("Users");
        }

        public async Task<List<User>> Get()
        {
            var users = await this.Collection.Find(_ => true).ToListAsync();
            return users;
        }
        public async Task<bool> Get(string email)
        {
            var users = await this.Collection.Find(x => x.Email == email).ToListAsync();
            if (users.Count > 0)
                return true;

            return false;
        }
        public void Post(User user)
        {
            this.Insert(user);
        }
    }
}
