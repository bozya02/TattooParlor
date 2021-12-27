using Microsoft.AspNetCore.Mvc;
using Core;

namespace WebParlor.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Index(User user)
        {
            return View(DataAccess.GetSpecialRequests(user));
        }
    }
}
