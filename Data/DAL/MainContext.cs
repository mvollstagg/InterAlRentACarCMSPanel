using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace Data.DAL
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

        public DbSet<Letter> Letters { get; set; }  
        public DbSet<User> Users { get; set; }      
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SiteSettings> SiteSettings { get; set; } 
        public DbSet<Car> Cars { get; set; } 
    }
}
