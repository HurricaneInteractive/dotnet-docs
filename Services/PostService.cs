using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Docs.Models;

namespace Docs.Services
{
  public class PostService
  {
    private readonly DocsContext _context;

    public PostService(DocsContext context)
    {
      _context = context;
    }

    private IQueryable<Post> GetPostById(int id) =>
      from post in _context.Posts
      where post.Id == id
      select post;

    public async Task<List<Post>> GetAll()
    {
      List<Post> posts = await _context.Posts.ToListAsync();
      return posts;
    }

    public async Task<Post> GetPost(int id)
    {
      Post post = await _context.Posts.FindAsync(id);
      return post;
    }

    public async Task<Post> Create(Post post)
    {
      post.CreatedAt = DateTime.UtcNow;

      _context.Posts.Add(post);
      await _context.SaveChangesAsync();

      return post;
    }

    public async Task UpdatePost(Post post)
    {
      _context.Entry(post).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task<bool> RemovePost(int id)
    {
      Post post = await GetPost(id);

      if (post == null)
      {
        return false;
      }

      _context.Posts.Remove(post);
      await _context.SaveChangesAsync();

      return true;
    }
  }
}
