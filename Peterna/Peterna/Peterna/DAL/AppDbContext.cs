using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Peterna.Models;

namespace Peterna.DAL
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Service> Services { get; set; }  
        public DbSet<AppUser> Users { get; set; }  
        public DbSet<Setting> Settings { get; set; }  
    }
}
