using E_Commerce.API.Models.DTO;
using E_Commerce.API.Repositories;
using E_Commerce.API.Repositories.Interfaces;
using E_Commerce.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegisterService registerService;
        private readonly ILoginService loginService;

        public AuthController(IRegisterService registerService, ILoginService loginService)
        {
            this.registerService = registerService;
            this.loginService = loginService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var registerResponse = await registerService.Register(registerRequestDto);

            if (registerResponse != null)
            {
                return Ok("Registered. Please Login!");
            }
            return BadRequest("Register Failed");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var loginResponse = await loginService.Login(loginRequestDto);
            
            if (loginResponse != null)
            {
                return Ok(loginResponse);
            }
            return BadRequest("Email or Password Incorrect");
        }
    }
}
