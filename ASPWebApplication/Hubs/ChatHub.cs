using ASPWebApplication.Data;
using ASPWebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NuGet.Packaging.Signing;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using NuGet.Protocol.Plugins;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Newtonsoft.Json;
//using Microsoft.AspNet.Identity;
namespace ASPWebApplication.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;
        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }


        //public async Task CreateRoom(string user_id, int contact_id, string room_name, string email)
        //{
        //    var loged_in_user = _context.Contact.Where(c => c.Id == contact_id).First();
        //    var other_user = _context.Contact.Where(c => c.User.Email == email).First();

        //    var chat_room = new ChatRoom()
        //    {
        //        Name = room_name,
        //    };
        //    _context.ChatRoom.Add(chat_room);
        //    _context.SaveChanges();

        //    loged_in_user.ChatRooms.Add(chat_room);
        //    other_user.ChatRooms.Add(chat_room);
        //}

        public async Task ContactList(string user_id)
        {
            var contact = _context.Contact.Where(c => c.User.Id == user_id).First();
            foreach (var c in contact.ChatRooms)
            {
                System.Diagnostics.Debug.WriteLine("-----------------------"+c.Name);
            }
        }

        

        public async Task FetchMessages(int chat_room_id, string user_id)
        {
            System.Diagnostics.Debug.WriteLine("Fetching..........................");

            var messages_list = _context.Message.Where(m => m.ChatRoomId == chat_room_id).OrderBy(o => o.Timestamp).ToList();
            string res = JsonConvert.SerializeObject(messages_list);
            await Clients.All.SendAsync("FetchMessages", res);
        }

        public async Task SendMessage(string user_id, string message, int chat_room_id)
        {
            //try
            //{
                var sender_id = "1a8de800-6908-4f54-a2c4-43223f2e5530";
                var chat_room = _context.ChatRoom.Where(c => c.Id == chat_room_id).FirstOrDefault();
                var sender = _context.Users.Where(u => u.Id == user_id).FirstOrDefault();
                System.Diagnostics.Debug.WriteLine("-----------------------Entering into Exisisting Room...");
                var msg = new Models.Message()  // we added model just because, before it showing me abiguity
                                                // with name Message in Nuget 
                {
                    Text = message,
                    Timestamp = DateTime.Now,
                    ChatRoomId = chat_room.Id,
                    ChatRoomObj = chat_room,
                    SenderId = sender.Id,
                    SenderObj = sender,

                };
                _context.Message.Add(msg);
                _context.SaveChanges();

                chat_room.MessageObjs.Add(msg);

                _context.ChatRoom.Update(chat_room);
                _context.SaveChanges();

                //await FetchMessages(chat_room_id, user_id);

                await Clients.All.SendAsync("ReceiveMessage", user_id, message, chat_room_id);

            //}
            //catch {
                //System.Diagnostics.Debug.WriteLine("-----------------------New Room Creating...");
                //var chat_room = new ChatRoom()
                //{
                //    Name = "New Room"
                //};
                //_context.ChatRoom.Add(chat_room);
                //_context.SaveChanges();
            //}
        }
        
    }
}
