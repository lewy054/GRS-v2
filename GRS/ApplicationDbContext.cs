using GRS.Model.Forum;
using GRS.Model.User;
using Microsoft.EntityFrameworkCore;
using Thread = GRS.Model.Forum.Thread;

namespace GRS;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Thread> Threads { get; set; }
    public DbSet<Role> Roles { get; set; }

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
            user.HasMany<Comment>(e => e.Comments)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Role>(role =>
        {
            role.HasKey(r => r.Id);
            role.Property(r => r.Name);
        });

        modelBuilder.Entity<Thread>(thread =>
        {
            thread.HasKey(t => t.Id);
            thread.Property(t => t.Id).ValueGeneratedNever();
            thread.Property(t => t.Title);
            thread.Property(t => t.Content);
            thread.Property(t => t.StartDate);
            thread.Property(t => t.Closed);
            thread.HasOne<User>(t => t.Author)
                .WithMany(e => e.Threads);
            thread.HasMany<Comment>(e => e.Comment)
                .WithOne(e => e.Thread);
        });

        modelBuilder.Entity<Comment>(comment =>
        {
            comment.HasKey(c => c.Id);
            comment.Property(c => c.Id).ValueGeneratedNever();
            comment.Property(c => c.Content);
            comment.HasOne<User>(c => c.User)
                .WithMany(c => c.Comments);
        });
    }
}