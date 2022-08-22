using BackEnd.Core.Interfaces;
using BackEnd.Core.Models;
using BackEnd.Core.Services.Posts.Models;
using BackEnd.Shared.Extensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BackEnd.Core.Services.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, PostApiModel>
    {
        private readonly IPostStore _postStore;

        public CreatePostCommandHandler(IPostStore postStore)
        {
            _postStore = postStore.ThrowIfNull(nameof(postStore));
        }

        public async Task<PostApiModel> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            request.ThrowIfNull(nameof(request));

            var post = await _postStore.Add(ToPostModel(request), cancellationToken);

            return ToPostApiModel(post);
        }

        private static Post ToPostModel(CreatePostCommand request)
        {
            return new Post()
            {
                Content = request.Content,
                PhotoUrl = request.PhotoUrl
            };
        }

        private static PostApiModel ToPostApiModel(Post post)
        {
            return new PostApiModel()
            {
                Id = post.Id,
                Content = post.Content,
                PhotoUrl = post.PhotoUrl
            };
        }
    }
}
