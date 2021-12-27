using Microsoft.AspNetCore.Mvc;
using Core;

namespace WebParlor.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {

            if (DataAccess.IsCorrectLogin(user.Login, user.Password))
            {
                return RedirectToAction("Index", "Home", DataAccess.GetUser(user.Login, user.Password));
            }
            ModelState.AddModelError("", "Invalid login or password");
            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (DataAccess.RegistrationUser(user))
            {
                return RedirectToAction("Index", "Home", DataAccess.GetUser(user.Login, user.Password));
            }

            ModelState.AddModelError("", "Invalid data");

            return View(user);
        }
    }
}
