using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Docs.Models
{
  public class DocsContext : DbContext
  {
    public DocsContext(DbContextOptions<DocsContext> options): base(options)
    {}

    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }
  }
}
