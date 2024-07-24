using Project.Identity.Configurations;
using Project.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Project.Identity;

public class ProjectIdentityDbContext : IdentityDbContext<AppUser>
{
    public ProjectIdentityDbContext(DbContextOptions<ProjectIdentityDbContext> options) :
        base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UserConfiguration());
    }
}