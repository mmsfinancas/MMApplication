using MMDomain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMInfra
{
    public class UserDB
    {
        public async Task<List<User>> Get()
        {
            DBDAO db = new DBDAO();
            var coll = db.database.GetCollection<User>("Users");
            var users = await coll.Find(_ => true).ToListAsync();
            return users;
        }

        public async void Post(User user)
        {
            DBDAO db = new DBDAO();
            var coll = db.database.GetCollection<User>("Users");

            coll.InsertOne(user);
        }
    }
}
