using MMDomain;
using MMInfra.Config;
using MMInfra.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMInfra
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

        public async Task<List<User>> Get(string email)
        {
            var users = await this.Collection.Find(x => x.Email == email).ToListAsync();
            return users;
        }

        public void Post(User user)
        {
            this.Insert(user);
        }
    }
}
