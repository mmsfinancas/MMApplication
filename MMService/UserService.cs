using MMDomain;
using MMInfra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMService
{
    public class UserService
    {
        public void Post(User users)
        {
            UserDB newUser = new UserDB();

            newUser.Post(users);
        }

        public async Task<List<User>> Get()
        {
            UserDB newUser = new UserDB();

            return await newUser.Get();
        }
    }
}
