using System;
using System.ComponentModel.DataAnnotations;

namespace ASPWebApplication.Models
{
    public class ChatRoom
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Message> MessageObjs { get; set; } = new List<Message>();
    }
   
}
