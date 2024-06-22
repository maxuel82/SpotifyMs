using Microsoft.AspNetCore.Mvc;

namespace SpotifyMs.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
