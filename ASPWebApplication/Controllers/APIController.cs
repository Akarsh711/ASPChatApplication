﻿//using ASPWebApplication.Data;
//using ASPWebApplication.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//namespace ASPWebApplication.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class APIController : ControllerBase
//    {
//        private readonly UserManager<IdentityUser> _userManager;
//        private readonly ApplicationDbContext _context;

//        public APIController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
//        {
//            _userManager = userManager;
//            _context = context;
//        }

//        public async Task<IActionResult> Index()
//        {
//            return Content("dfdfdf");
//        }
//        //[Authorize]
//        //public async Task<IActionResult> Index()
//        //{
//        //    var user = await _userManager.GetUserAsync(User);

//        //    Contact contact;
//        //    try
//        //    {
//        //        contact = _context.Contact.Where(c => c.User.Id == user.Id).First();
//        //    }
//        //    catch
//        //    {
//        //        contact = new Contact()
//        //        {
//        //            User = user,
//        //            ChatRooms = new List<ChatRoom>()
//        //        };
//        //        _context.Contact.Add(contact);
//        //        _context.SaveChanges();
//        //    }
//        //    System.Diagnostics.Debug.WriteLine("-----------------------create room running..." + contact.User.Id);

//        //    return RedirectToAction("ChatView");
//        //}

//        [Authorize]
//        public async Task<IActionResult> ChatView()
//        {
//            IdentityUser user = await _userManager.GetUserAsync(User);
//            Contact contact = _context.Contact.Where(u => u.User == user).Include(u => u.ChatRooms).FirstOrDefault();

//            ICollection<ChatRoom> chat_room_list = _context.ChatRoom.Where(c => c.ContactObjs.Any(contact => contact.User == user)).ToList();

//            System.Diagnostics.Debug.WriteLine("redirected.........");

//            return Content("dfdfdf");
//        }

//        [ValidateAntiForgeryToken]
//        [Authorize]
//        public async Task<IActionResult> CreateRoom(int contact_id, string email, string room_name)
//        {
//            Contact loged_in_user = _context.Contact.Where(c => c.Id == contact_id).Include(c => c.ChatRooms).First();
//            Contact other_user = _context.Contact.Where(c => c.User.Email == email).Include(c => c.ChatRooms).First();

//            ICollection<Contact> contact_list = new List<Contact>();
//            contact_list.Add(loged_in_user);
//            contact_list.Add(other_user);

//            ChatRoom chat_room = new ChatRoom()
//            {
//                Name = room_name,
//                ContactObjs = contact_list,
//            };
//            _context.ChatRoom.Add(chat_room);
//            _context.SaveChanges();
//            return Redirect("Index");
//        }
//    }
//}


using ASPWebApplication.Data;
using ASPWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using ASPWebApplication.DTO;
using Azure.Identity;

namespace ASPWebApplication.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class APIController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public APIController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            Contact contact;
            try
            {
                contact = _context.Contact.Where(c => c.User.Id == user.Id).First();
            }
            catch
            {
                contact = new Contact()
                {
                    User = user,
                    ChatRooms = new List<ChatRoom>()
                };
                _context.Contact.Add(contact);
                _context.SaveChanges();
            }
            System.Diagnostics.Debug.WriteLine("-----------------------create room running..." + contact.User.Id);

            //var id = User.Identity.GetUserId();
            ViewData["id"] = user.Id.ToString();
            ViewData["user"] = user;
            ViewData["contact_id"] = contact.Id;
            // return View();
            return RedirectToAction("ChatView2");
        }

        [Authorize]
        public async Task<ActionResult<IEnumerable<ChatRoom>>> ChatView2()
        {
            IdentityUser user = await _userManager.GetUserAsync(User);
            Contact contact = _context.Contact.Where(u => u.User == user).Include(u => u.ChatRooms).FirstOrDefault();

            ICollection<ChatRoom> chat_room_list = _context.ChatRoom.Where(c => c.ContactObjs.Any(contact => contact.User == user)).ToList();

            var obj = chat_room_list.Select(room => new ChatRoom
            {
                Id = room.Id,
               
                MessageObjs = room.MessageObjs,
                ContactObjs = room.ContactObjs.Select(contact => new Contact
                {
                    
                    User = new IdentityUser
                    {
                        UserName = contact.User.UserName,
                    }
                
                }).ToList()
            });

            ViewData["id"] = user.Id.ToString();
            ViewData["user"] = user;
            ViewData["contact_id"] = contact.Id;
            ViewData["chat_room_list"] = chat_room_list;

            System.Diagnostics.Debug.WriteLine("redirected.........");


            //return Ok(chat_room_list);
            return Ok(obj);
        }   

        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateRoom2(int contact_id, string email, string room_name)
        {
            Contact loged_in_user = _context.Contact.Where(c => c.Id == contact_id).Include(c => c.ChatRooms).First();
            Contact other_user = _context.Contact.Where(c => c.User.Email == email).Include(c => c.ChatRooms).First();

            ICollection<Contact> contact_list = new List<Contact>();
            contact_list.Add(loged_in_user);
            contact_list.Add(other_user);

            ChatRoom chat_room = new ChatRoom()
            {
                Name = room_name,
                ContactObjs = contact_list,
            };
            _context.ChatRoom.Add(chat_room);
            _context.SaveChanges();
            return Redirect("Index");




            //Contact loged_in_user = _context.Contact.Where(c => c.Id == contact_id).Include(c => c.ChatRooms).First();
            //Contact other_user = _context.Contact.Where(c =>c.User.Email == email).Include(c => c.ChatRooms).First();


            //ChatRoom chat_room = new ChatRoom()
            //{
            //    Name = room_name,

            //};

            //other_user.ChatRooms.Add(chat_room);
            //ChatRoom chat_room2 = new ChatRoom()
            //{
            //    Name = room_name,
            //};
            //loged_in_user.ChatRooms.Add(chat_room2);
            //_context.SaveChanges();

            //return View("Index");
        }




        public async Task<IActionResult> Test2()
        {
            var c1 = _context.Contact.Where(c => c.Id == 5).Include(cr => cr.ChatRooms).First();
            var c2 = _context.Contact.Where(c => c.Id == 6).Include(cr => cr.ChatRooms).First();
            System.Diagnostics.Debug.WriteLine("----------------------c1/test..." + c1.ChatRooms.First().Id);
            System.Diagnostics.Debug.WriteLine("-----------------------c2/test2..." + c2.ChatRooms.First().Id);
            return Content("success");

        }
    }
}
