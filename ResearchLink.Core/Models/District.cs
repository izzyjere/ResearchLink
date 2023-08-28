namespace ResearchLink.Core.Models;

public class District : Entity
{
    public string Name { get; set; }
    public Guid ProvinceId { get; set; }
    public virtual Province Province { get; set; }
}
