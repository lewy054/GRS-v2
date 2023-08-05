using GRS.Model;
using GRS.Model.User;
using Microsoft.EntityFrameworkCore;

namespace GRS;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(user =>
        {
            user.HasKey(u => u.Id);
            user.Property(u => u.Id).ValueGeneratedNever();
            user.Property(u => u.UserName);
            user.Property(u => u.PasswordHash);
            user.HasMany<Role>(e => e.Roles)
                .WithMany(e => e.Users);
        });
        modelBuilder.Entity<Role>(role =>
        {
            role.HasKey(r => r.Id);
            role.Property(r => r.Name);
        });
    }
}