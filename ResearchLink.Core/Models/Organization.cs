namespace ResearchLink.Core.Models;

public class Organization : Entity
{
    public string Name { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}
