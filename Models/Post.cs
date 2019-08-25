using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Docs.Models
{
  public class Post
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Content { get; set; }
    public List<Tag> Tags { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}
