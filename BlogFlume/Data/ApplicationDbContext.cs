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
    public DbSet<BlogFlume.Models.Blog>? Blog { get; set; }
    public DbSet<BlogFlume.Models.Comment>? Comment { get; set; }
    public DbSet<BlogFlume.Models.Post>? Post { get; set; }
    public DbSet<BlogFlume.Models.Tag>? Tag { get; set; }
}