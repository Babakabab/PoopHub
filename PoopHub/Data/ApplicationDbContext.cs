using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PoopHub.Models;

namespace PoopHub.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<PoopHub.Models.Toilet>? Toilet { get; set; }
    public DbSet<PoopHub.Models.User>? User { get; set; }
}

