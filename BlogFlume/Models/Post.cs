using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlogFlume.Enums;

namespace BlogFlume.Models;

public class Post
{
    public Post(int id, int blogId, string authorId, string title, string @abstract, string content, DateTime created, DateTime? updated, ReadyStatus readyStatus, string slug, byte[] imageData, string contentType)
    {
        Id = id;
        BlogId = blogId;
        AuthorId = authorId;
        Title = title;
        Abstract = @abstract;
        Content = content;
        Created = created;
        Updated = updated;
        ReadyStatus = readyStatus;
        Slug = slug;
        ImageData = imageData;
        ContentType = contentType;
    }

    public int Id { get; set; }
    public int BlogId { get; set; }
    public string AuthorId { get; set; }

    [Required]
    [StringLength(75, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 2)]
    public string Title { get; set; }

    [Required]
    [StringLength(200, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 2)]
    public string Abstract { get; set; }

    [Required]
    public string Content { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Created Date")]
    public DateTime Created { get; set; }
    
    [DataType(DataType.Date)]
    [Display(Name = "Updated Date")]
    public DateTime? Updated { get; set; }

    public ReadyStatus ReadyStatus { get; set; }

    public string Slug { get; set; }

    public byte[] ImageData { get; set; }
    public string ContentType { get; set; }
    
    [NotMapped]
    public IFormFile? Image { get; set; }
    
    // Navigation properties
    public virtual Blog? Blog { get; set; }
    public virtual BlogUser? Author { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
}