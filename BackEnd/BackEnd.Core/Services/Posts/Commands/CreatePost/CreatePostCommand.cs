using BackEnd.Core.Services.Posts.Models;
using MediatR;

namespace BackEnd.Core.Services.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<PostApiModel>
    {
        public string Content { get; set; }
        public string PhotoUrl { get; set; }
    }
}
