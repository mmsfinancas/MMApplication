using MMDomain;
using MMInfra.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMInfra
{
    public class UserDB : IUserDB
    {
        public async Task<List<User>> Get()
        {
            DBDAO db = new DBDAO();
            var coll = db.database.GetCollection<User>("Users");
            var users = await coll.Find(_ => true).ToListAsync();
            return users;
        }

        public void Post(User user)
        {
            DBDAO db = new DBDAO();
            var coll = db.database.GetCollection<User>("Users");

            coll.InsertOne(user);
        }
    }
}
