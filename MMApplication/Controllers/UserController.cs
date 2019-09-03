﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MMDomain;
using MMService.Interfaces;

namespace MMApplication.Controllers
{
    [Route("api/[controller]")]
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
            return await _service.Get();
        }

        [HttpPost]
        public void Post(User users)
        {
            _service.Post(users);
        }
    }
}