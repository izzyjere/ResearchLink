namespace ResearchLink.Core.Models;

public class Journal : Entity
{
    public string Name { get; set; } 
    public string Description { get; set; }
    public ICollection<Volume> Volumes { get; set; }
}

