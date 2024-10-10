using Microsoft.AspNetCore.Mvc;

namespace Personal_Finance_Manager.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
