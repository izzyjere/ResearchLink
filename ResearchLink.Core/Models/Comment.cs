namespace ResearchLink.Core.Models
{
    public class Comment : Entity
    {
        public Guid ArticleId { get; set; }
        public string Content { get; set; }
        public Guid? UserId { get; set; }
        public Article Article { get; set; }
        public ICollection<CommentReply> Replies { get; set; }
    }
}
