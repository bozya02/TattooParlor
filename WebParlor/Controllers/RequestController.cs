using Microsoft.AspNetCore.Mvc;
using Core;

namespace WebParlor.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Index(User user)
        {
            return View(user);
        }

        [HttpGet]
        public IActionResult AddRequest(User user)      //Обязательно исправить: неиспользуемый аргумент метода (Мясников, Сематкин) 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRequest(Request request)
        {
            DataAccess.AddNewRequest(request);
            return RedirectToAction("Index", request.IdUser);
        }
    }
}
