using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Docs.Models;
using Docs.Services;

namespace Docs.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostsController : ControllerBase
  {
    private readonly PostService _service;

    public PostsController(PostService service)
    {
      _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAllPosts()
    {
      List<Post> posts = await _service.GetAll();

      if (posts.Count == 0)
      {
        return NotFound();
      }

      return posts;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetSinglePost(int id)
    {
      Post post = await _service.GetPost(id);

      if (post == null)
      {
        return NotFound();
      }

      return post;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
      Post newPost = await _service.Create(post);
      return CreatedAtAction(nameof(GetSinglePost), new { id = post.Id }, newPost);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(int id, Post post)
    {
      if (id != post.Id)
      {
        return BadRequest();
      }

      await _service.UpdatePost(post);

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
      bool deleted = await _service.RemovePost(id);

      if (!deleted)
      {
        return NotFound();
      }

      return NoContent();
    }
  }
}
