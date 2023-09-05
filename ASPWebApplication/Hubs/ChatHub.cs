using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
//using Microsoft.AspNet.Identity;
namespace ASPWebApplication.Hubs
{
    public class ChatHub: Hub
    {
        
        public async Task SendMessage(string user, string message)
        {

            //var uss = Context.User.Identity;
            //System.Diagnostics.Debug.WriteLine("-------------dfdf"+uss);
           
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
