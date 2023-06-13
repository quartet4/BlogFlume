using System.ComponentModel.DataAnnotations;

namespace BlogFlume.Models;

public class Tag
{
    public Tag(int id, int postId, string authorId, string text, Post post, BlogUser author)
    {
        Id = id;
        PostId = postId;
        AuthorId = authorId;
        Text = text;
        Post = post;
        Author = author;
    }

    public int Id { get; set; }
    public int PostId { get; set; }
    public string AuthorId { get; set; }

    [Required]
    [StringLength(25, ErrorMessage = "The {0} must be between {2} and {1} characters", MinimumLength = 2)]
    public string Text { get; set; }
    
    // Navigation properties
    public virtual Post Post { get; set; }
    public virtual BlogUser Author { get; set; }
    
}