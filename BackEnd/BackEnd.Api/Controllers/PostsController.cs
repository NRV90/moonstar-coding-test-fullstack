using System.Threading.Tasks;
using BackEnd.Core.Services.Posts.Commands.CreatePost;
using BackEnd.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostDbContext _postDbDbContext;
        private readonly IMediator _mediatr;
        public PostsController(PostDbContext postDbDbContext, IMediator mediatr)
        {
            _postDbDbContext = postDbDbContext;
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postDbDbContext
                .Posts
                .ToListAsync();

            if (posts is null)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var post = await _postDbDbContext
                .Posts
                .SingleOrDefaultAsync(post => post.Id.Equals(id));

            if (post is null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostCommand createPostCommand)
        {
            var post = await _mediatr.Send(createPostCommand);

            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }
    }
}