using Microsoft.AspNetCore.Mvc;

namespace Personal_Finance_Manager.Controllers
{
    public class AuthController : Controller
    {
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
