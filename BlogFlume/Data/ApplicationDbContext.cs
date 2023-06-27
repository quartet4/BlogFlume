using BlogFlume.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogFlume.Data;

public class ApplicationDbContext : IdentityDbContext<BlogUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Blog>? Blog { get; set; }
    public DbSet<Comment>? Comment { get; set; }
    public DbSet<Post>? Post { get; set; }
    public DbSet<Tag>? Tag { get; set; }
}