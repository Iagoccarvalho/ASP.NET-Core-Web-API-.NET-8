using Api_NET8.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api_NET8.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>  
    {
        public ApplicationDBContext(DbContextOptions dbContextOpions) : base(dbContextOpions){ }

        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
