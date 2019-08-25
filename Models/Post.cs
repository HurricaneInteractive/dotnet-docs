using System.Collections.Generic;

namespace Docs.Models
{
  public class Post
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }

    public List<Tag> Tags { get; set; }
  }
}
