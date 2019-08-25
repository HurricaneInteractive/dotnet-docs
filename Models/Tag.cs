using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Docs.Models
{
  public class Tag
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
  }
}
