﻿
namespace ResearchLink.Core.Models;

public class Document : Entity
{
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public Guid ResearchId { get; set; }
    public DateTime DateUploaded { get; set; }
    public Document()
    {
       DateUploaded = DateTime.Now;
    }
    public string Path { get; set; }
    public virtual Research Research { get; set; }
}
