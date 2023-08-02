﻿namespace ResearchLink.Core.Models;
public class Article  : Entity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime DatePublished { get; set; }
    public ICollection<Citation> Citations { get; set; }  
    public ICollection<AuthorArticle> Authors { get; set; }

}

