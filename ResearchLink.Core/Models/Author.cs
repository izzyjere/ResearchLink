using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchLink.Core.Models;

public class Author : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Initials { get; set; }
    public string Title { get; set; }
    [MaxLength(10000)]
    public string Biography { get; set; }   
    public string EmailAddress { get; set; }
    public DateTime DateJoined { get; set; }
    public List<AuthorArticle> Articles { get; set; }
    public Guid UserId { get; set; }
    public string? Affliation { get; set; }
    public FileModel? Avatar { get; set; }
    public bool HasAvatar => Avatar != null;
    [NotMapped]
    public bool ViewFullBiography { get; set; }
}
