using ASPWebApplication.Data;
using ASPWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace ASPWebApplication.Controllers
{

    public class ChatController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ChatController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        private readonly ApplicationDbContext _context;
        
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            //var id = User.Identity.GetUserId();
            ViewData["id"] = user.Id.ToString();
            ViewData["user"] = user;
            //Identit
            return View();
        }
    }
}
