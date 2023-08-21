namespace ResearchLink.Core.Models
{
    public class CommentReply
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; }
        public Guid? UserId { get; set; }
        public Comment Comment { get; set; }
    }   
}
