using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("users")]
    public class UsersController : CustomController
    {
        private readonly IAuthAppService _authAppService;
        public UsersController (IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }
        [HttpPost("/register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister user)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return CustomResponse<TokenResponse>(await _authAppService.RegisterUser(user));
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] Login login) {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return CustomResponse<TokenResponse>(await _authAppService.Login(login));
        }
        
    }
}

