namespace ResearchLink.Core.Models;

public class District : Entity
{
    public string Name { get; set; }     
    public virtual string Province { get; set; }
}
