using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BlogFlume.Models;

public class BlogUser : IdentityUser
{
    [Required]
    [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 2)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 2)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    public byte[]? ImageData { get; set; }
    public string? ContentType { get; set; }

    [StringLength(100, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 10)]
    public string FacebookUrl { get; set; }
    [StringLength(100, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 10)]
    public string TwitterUrl { get; set; }

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";

    public virtual ICollection<Blog> Blogs { get; set; } = new HashSet<Blog>();
    public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

}