using ASPWebApplication.Data;
using ASPWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASPWebApplication.Controllers
{

    public class ChatController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;


        public ChatController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;

        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            int id = 1;
            Contact contact;
            try
            {
                contact =  _context.Contact.Where(c => c.User.Id == user.Id).First();
            }
            catch
            {
                contact = new Contact()
                {
                    User = user,
                };
                _context.Contact.Add(contact);
                _context.SaveChanges();
            }
            System.Diagnostics.Debug.WriteLine("-----------------------create room running..." + contact.User.Id);

            //var id = User.Identity.GetUserId();
            ViewData["id"] = user.Id.ToString();
            ViewData["user"] = user;
            ViewData["contact_id"] = contact.Id;
            //Identit
            return View();
        }


        

        
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateRoom(int contact_id, string email, string room_name)
        {
            

            Contact loged_in_user = _context.Contact.Where(c => c.Id == contact_id).Include(c => c.User).First();
            Contact other_user = _context.Contact.Where(c => c.User.Email == email).First();
            //System.Diagnostics.Debug.WriteLine("-----------------------create room running...");
            //System.Diagnostics.Debug.WriteLine("-----------------------create room running..." + contact_id);

            //var usr = loged_in_user.User;
            //System.Diagnostics.Debug.WriteLine("-----------------------create room running..."+usr.Email.ToString());
            //System.Diagnostics.Debug.WriteLine("-----------------------create room running..."+other_user.User.Id);


            var chat_room = new ChatRoom()
            {
                Name = room_name,
            };

            _context.ChatRoom.Add(chat_room);
            //_context.SaveChanges();

            //_context.Update(loged_in_user);

            other_user.ChatRooms.Add(chat_room);
            //_context.SaveChanges();

            loged_in_user.ChatRooms.Add(chat_room);
            _context.SaveChanges();

            //_context.Update(other_user);


            _context.Entry(loged_in_user).State = EntityState.Modified;
            
            _context.SaveChanges();
            
            System.Diagnostics.Debug.WriteLine("-----------------------state"+ _context.Entry(other_user).State);

            return View("Index");
        }


        public async Task<IActionResult> Test()
        {
            var c1 = _context.Contact.Where(c => c.Id == 5).Include(cr => cr.ChatRooms).First();
            var c2 = _context.Contact.Where(c => c.Id == 6).Include(cr => cr.ChatRooms).First();
            System.Diagnostics.Debug.WriteLine("----------------------c1/test..." + c1.ChatRooms.First().Id);
            System.Diagnostics.Debug.WriteLine("-----------------------c2/test2..." + c2.ChatRooms.First().Id);
            return Content("success");

        }
    }
}
