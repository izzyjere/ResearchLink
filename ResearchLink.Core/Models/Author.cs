﻿namespace ResearchLink.Core.Models;

public class Author : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Initials { get; set; }
    public string Title { get; set; }
    [MaxLength(10000)]
    public string Biography { get; set; }   
    public string EmailAddress { get; set; }
    public DateTime DateJoined { get; set; }
    public List<AuthorArticle> Articles { get; set; }

}
