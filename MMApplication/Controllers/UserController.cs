using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMDomain;
using MMService;

namespace MMApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/Users
        [HttpGet]
        public async Task<List<User>> Get()
        {
            UserService userModel = new UserService();
            return await userModel.Get();
        }

        // POST: api/Users
        [HttpPost]
        public void Post(User users)
        {
            UserService userModel = new UserService();
            userModel.Post(users);
        }
    }
}