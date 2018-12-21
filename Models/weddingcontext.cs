using Microsoft.EntityFrameworkCore;
 
namespace WeddingPlanner.Models
{
    public class weddingcontext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public weddingcontext(DbContextOptions<weddingcontext> options) : base(options) { }
        public DbSet<User> Users{get;set;}
        public DbSet<Wedding> Weddings{get;set;}
        public DbSet<RSVP> RSVPs{get;set;}
    }
}
