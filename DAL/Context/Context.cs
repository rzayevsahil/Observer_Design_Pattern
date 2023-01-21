using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Observer_Design_Pattern.DAL.Entities;

namespace Observer_Design_Pattern.DAL.Context
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-2H5V0KB\\SQLEXPRESS;initial catalog=DbObserver;integrated security=true;");
        }

        public DbSet<Discount> Discounts { get; set; }
    }
}
