using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMDomain.User;
using MMService.Interfaces;

namespace MMApplication.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserResetPasswordController : ControllerBase
    {
        private readonly IUserService _service;
        public UserResetPasswordController(IUserService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<string> Post(UserResetPassword userEmail)
        {
            return await _service.Post(userEmail.Email);
        }
    }
}