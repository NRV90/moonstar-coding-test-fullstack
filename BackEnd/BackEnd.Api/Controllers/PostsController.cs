using System;
using System.IO;
using System.Threading.Tasks;
using BackEnd.Core.Services.File.Commands.CreateFile;
using BackEnd.Core.Services.File.Commands.UpdateFile;
using BackEnd.Core.Services.Posts.Commands.CreatePost;
using BackEnd.Core.Services.Posts.Commands.DeletePost;
using BackEnd.Core.Services.Posts.Commands.UpdatePost;
using BackEnd.Core.Services.Posts.Models;
using BackEnd.Core.Services.Posts.Queries.GetPostById;
using BackEnd.Core.Services.Posts.Queries.GetPosts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public PostsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int skip, int take)
        {
            var posts = await _mediatr.Send(new GetPostsQuery(skip, take));

            return Ok(posts);
        }

        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _mediatr.Send(new GetPostByIdQuery(id));

            if (post is null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm(Name = "content")] string content, [FromForm(Name = "document")] IFormFile file)
        {
            var command = new CreatePostCommand
            {
                Content = content,
                PhotoUrl = await _mediatr.Send(new CreateFileCommand(file))
            };

            var post = await _mediatr.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromForm(Name = "content")] string content, [FromForm(Name = "document")] IFormFile file, [FromForm(Name = "filePath")] string filePath, [FromForm(Name = "id")] int id)
        {
            var command = new UpdatePostCommand(new PostApiModel()
            {
                Content = content,
                PhotoUrl = await _mediatr.Send(new UpdateFileCommand(file, filePath)),
                Id = id
            });

            var post = await _mediatr.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var posts = await _mediatr.Send(new DeletePostCommand(id));

            return Ok(posts);
        }
    }
}