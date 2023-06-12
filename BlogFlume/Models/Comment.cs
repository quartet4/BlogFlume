using System.ComponentModel.DataAnnotations;
using BlogFlume.Enums;
using Microsoft.AspNetCore.Identity;

namespace BlogFlume.Models;

public class Comment
{
    public Comment(int id, int postId, string authorId, string moderatorId, string body, DateTime created, DateTime? updated, DateTime? moderated, DateTime? deleted, string moderatedBody, ModerationType moderationType, Post post, IdentityUser author, IdentityUser moderator)
    {
        Id = id;
        PostId = postId;
        AuthorId = authorId;
        ModeratorId = moderatorId;
        Body = body;
        Created = created;
        Updated = updated;
        Moderated = moderated;
        Deleted = deleted;
        ModeratedBody = moderatedBody;
        ModerationType = moderationType;
        Post = post;
        Author = author;
        Moderator = moderator;
    }

    public int Id { get; set; }
    public int PostId { get; set; }
    public string AuthorId { get; set; }
    public string ModeratorId { get; set; }

    [Required]
    [StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} characters", MinimumLength = 2)]
    [Display(Name = "Comment")]
    public string Body { get; set; }

    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public DateTime? Moderated { get; set; }
    public DateTime? Deleted { get; set; }
    
    [StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} characters", MinimumLength = 2)]
    [Display(Name = "Moderated Comment")]
    public string ModeratedBody { get; set; }

    public ModerationType ModerationType { get; set; }
    
    // Navigation properties
    public virtual Post Post { get; set; }
    public virtual IdentityUser Author { get; set; }
    public virtual IdentityUser Moderator { get; set; }

}