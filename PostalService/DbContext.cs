using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PostalService.Model;
namespace PostalService

{
    public class DbContext : IdentityDbContext<User, UserRole, string>
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<Parcel> Parcels { get; set; } = null!;

        public DbContext(DbContextOptions<DbContext> contextOptions) : base(contextOptions)
        { }
    }
}
