using ASPWebApplication.Data;
using ASPWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPWebApplication.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context) => _context = context;


        //public HomeController(ILogger<HomeController> logger) => _logger = logger;


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Chat()
        {
            //Contact newobj = new() { Name = "boisa" };
            //_context.Add(newobj);
            //_context.SaveChanges();

            //var obj = _context.ContactViewModel.ToList();
            ////return Content(obj[0].Name.ToString());
            //ViewData["obj"] = obj;
            return View();
        }
    }
}