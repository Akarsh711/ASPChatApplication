using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASPWebApplication.Models;

namespace ASPWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public object Movie { get; internal set; }

        public DbSet<ASPWebApplication.Models.AppointmentViewModel> AppointmentViewModel { get; set; } = default!;
    }
}