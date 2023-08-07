namespace ResearchLink.Core.Shared;

public class FileModel
{
    public Guid Id { get; set; }    
    public string Path { get; set; }      
    public string ContentType { get; set; }
    public FileStore FileStore { get; set; }
}