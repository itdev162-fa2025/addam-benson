using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Domain;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly DataContext _context;

    public PostsController(DataContext context)
    {
        _context = context;

    }
    /// <summary>
    /// GET api/posts
    /// </Summary>
    /// <returns>returns a list of posts</returns>
    [HttpGet(Name = "GetPosts")]
    public ActionResult<List<Post>> Get()
    {
        return _context.Posts.ToList();
    }

    /// <summary>
    /// GET api/posts
    /// </Summary>
    /// <param name="id"=>post id</param>/// 
    /// <returns>returns a record matching id</returns>
    [HttpGet("{id}", Name = "GetById")]
    public ActionResult<Post> GetById(Guid id)
    {
        var post = _context.Posts.Find(id);
        if (post is null)
        {
            return NotFound();
        }

        return Ok(post);
    }

    /// <summary>
    /// Create api/posts
    /// </Summary>
    /// <param name="request"=>hydrate model</param>/// 
    /// <returns>returns the created post</returns>
    [HttpPost(Name = "Create")]
    public ActionResult<Post> Create([FromBody] Post request)
    {
        var post = new Post
        {
            Id = request.Id,
            Title = request.Title,
            Body = request.Body,
            Date = request.Date
        };

        _context.Add(post);
        var success = _context.SaveChanges() > 0;

        if (success)
        {
            return Ok(post);
        }
        throw new Exception("Error creating post");
    }

    /// <summary>
    /// PUT api/posts
    /// </Summary>
    /// <param name="request"=>hydrate model</param>/// 
    /// <returns>returns the created post</returns>
    [HttpPost(Name = "Update")]
    public ActionResult<Post> Update([FromBody] Post request)
    {
        var post = _context.Posts.Find(request.Id);
        if (post == null)
        {
            throw new Exception("Could not find post");
        }

        post.Title = request.Title != null ? request.Title : post.Title;
        post.Body = request.Body != null ? request.Body : post.Body;
        post.Date = request.Date != DateTime.MinValue ? request.Date : post.Date;
        var success = _context.SaveChanges() > 0;

        if (success)
        {
            return Ok(post);
        }
        throw new Exception("Error updating post");
    }

}