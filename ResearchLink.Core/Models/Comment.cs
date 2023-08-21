using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchLink.Core.Models
{
    public class Comment : Entity
    {
        public Guid ArticleId { get; set; }
        [Required(ErrorMessage = "Please provide a comment")]
        [MaxLength(250,ErrorMessage = "Comment cannot be more than 250 characters")]
        public string Content { get; set; }
        public string User { get; set; }
        public Article Article { get; set; }
        public ICollection<CommentReply> Replies { get; set; }
        [NotMapped]
        public bool Replying { get; set; }  
    }
}
