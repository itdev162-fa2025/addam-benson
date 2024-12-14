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

    //GET api/posts
    [HttpGet(Name = "GetPosts")]
    public ActionResult<List<Post>> Get()
    {
        return _context.Posts.ToList();
    }

}