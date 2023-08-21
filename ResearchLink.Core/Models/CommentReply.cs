namespace ResearchLink.Core.Models
{
    public class CommentReply
    {
        public Guid CommentId { get; set; }
        [Required(ErrorMessage = "Please provide a comment")]
        [MaxLength(250, ErrorMessage = "Comment cannot be more than 250 characters")]
        public string Content { get; set; }
        public Guid? UserId { get; set; }
        public Comment Comment { get; set; }
    }   
}
