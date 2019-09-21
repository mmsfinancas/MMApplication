using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MMDomain.User;
using MMService.Interfaces;

namespace MMApplication.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await _service.GetUsers();
        }

        [HttpPost]
        public void Post(User users)
        {
            _service.InsertUser(users);
        }
    }
}