namespace ResearchLink.Core.Models;

public class Volume : Entity
{
   public Guid JournalId { get; set; }
   public virtual Journal Journal { get; set; }
   public int Year { get; set; }
   public int Number { get; set; }
   public ICollection<Article> Articles { get; set; }
}

