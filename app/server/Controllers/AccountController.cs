using Microsoft.AspNetCore.Mvc;
namespace server.Controllers
{
    public record User(string Name, string Password);

    [ApiController]
    [Route("account/{action}")]
    public class AccountController : ControllerBase
    {
        public JsonResult SignUp()
        {
            User user = new("Dmitrij", "Password");
            return new JsonResult(user);
        }
        //public void SignIn()
        //{

        //}

        //public void Logout()
        //{

        //}
    }
}