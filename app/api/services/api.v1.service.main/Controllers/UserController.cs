using api.v1.service.main.DTOs.Users;
using api.v1.service.main.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace api.v1.service.main.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/v1/account")]
    public sealed class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;



        [HttpPost("signUp")]
        public IActionResult SignUp([FromBody][Required] UserSignUpDTO body) 
        { 
            _userService.SignUp(body); 
            return Ok("Пользователь был успешно зарегистрирован"); 
        }

        [HttpPost("signIn")]
        public IActionResult SignIn([FromBody][Required] UserSignInDTO body) 
        {
            var tokens = _userService.SignIn(body);
            Response.Cookies.Append("refresh_token", tokens.refresh_token, new CookieOptions
            {
                HttpOnly = false,
                Secure = false,
                SameSite = SameSiteMode.Strict
            });
            return Ok(tokens.access_token);
        }

        [HttpPut("refresh")]
        public IActionResult RefreshToken() 
        {
            var z = Request.Cookies.Select(x => x);
            return Ok(z);

            var refreshToken = GetRefreshToken();
            return Ok(_userService.UpdateAccessToken(refreshToken)); 
        }



        [NonAction]
        private string GetRefreshToken() => 
            Request.Cookies["refresh_token"] ?? "-1";
    }
}