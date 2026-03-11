using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Data.Movie> Movies { get; set; } = default!;
        public DbSet<Data.Country> Countries { get; set; } = default!;

        public DbSet<Data.Currency> Currencies { get; set; } = default!;
    }
}
