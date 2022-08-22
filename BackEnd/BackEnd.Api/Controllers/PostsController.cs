using System.Threading.Tasks;
using BackEnd.Core.Services.Posts.Commands.CreatePost;
using BackEnd.Core.Services.Posts.Queries.GetPostById;
using BackEnd.Core.Services.Posts.Queries.GetPosts;
using BackEnd.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            var posts = await _mediatr.Send(new GetPostsQuery());

            return Ok(posts);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var post = await  _mediatr.Send(new GetPostByIdQuery(id));

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