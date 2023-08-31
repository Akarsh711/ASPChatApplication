using ASPWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPWebApplication.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
