using Microsoft.AspNetCore.Identity;

namespace ASPWebApplication.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public ICollection<IdentityUser>? UserObjs { get; set; } // Mto1 Foreign Key

        public string? Friend { get; set; } // MtoM
        public string? Image { get; set; }
    }
}