using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Project.Identity;

public class ProjectIdentityDbContextFactory : IDesignTimeDbContextFactory<ProjectIdentityDbContext>
{
    public ProjectIdentityDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "../../Project.API")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<ProjectIdentityDbContext>();
        var connectionString = configuration.GetConnectionString("ProjectIdentityConnectionString");

        builder.UseNpgsql(connectionString);

        return new ProjectIdentityDbContext(builder.Options);
    }
}