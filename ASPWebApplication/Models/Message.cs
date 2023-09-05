using Microsoft.AspNetCore.Identity;

namespace ASPWebApplication.Models;

public class Message
{
    public int Id { get; set; }
    public ICollection<Contact>? ContactObjs { get; set; } // Mto1
    public string? Text { get; set; }
    public DateTime TimeStamp { get; set; }
}
