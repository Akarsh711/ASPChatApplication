using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPWebApplication.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public required IdentityUser User { get; set; }
        public ICollection<ChatRoom> ChatRooms { get; set; } = new List<ChatRoom>();
    }
}