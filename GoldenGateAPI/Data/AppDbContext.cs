using GoldenGateAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoldenGateAPI.Data;

public class AppDbContext : IdentityDbContext<User> // <User> User class represented to use in DB
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    // Create all tables in the DB defined by the context with his models
/*     protected override void OnModelCreating(ModelBuilder builder) 
    {
        base.OnModelCreating(builder);
    } */

    public DbSet<Property> Properties { get; set; }

}
