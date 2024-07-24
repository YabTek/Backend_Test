using Microsoft.EntityFrameworkCore;
using Project.Domain;
using Project.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Persistence
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring Recipe entity relationships
            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasOne(r => r.User)
                    .WithMany(u => u.Recipes)
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(r => r.Comments)
                    .WithOne(c => c.Recipe)
                    .HasForeignKey(c => c.RecipeId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(r => r.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(r => r.Instructions)
                    .IsRequired();

                entity.Property(r => r.PreparationTime)
                    .IsRequired();
            });

            // Configuring Comment entity relationships
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(c => c.Recipe)
                    .WithMany(r => r.Comments)
                    .HasForeignKey(c => c.RecipeId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(c => c.User)
                    .WithMany(u => u.Comments)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(c => c.Content)
                    .IsRequired();

                entity.Property(c => c.Date)
                    .IsRequired();
            });

            // Configuring User entity relationships
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.UserName)
                    .IsRequired();

                entity.Property(u => u.Email)
                    .IsRequired();

                // Configure one-to-many relationships with Recipe and Comment
                entity.HasMany(u => u.Recipes)
                    .WithOne(r => r.User)
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(u => u.Comments)
                    .WithOne(c => c.User)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Apply configurations from assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        // DbSets for entities
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
