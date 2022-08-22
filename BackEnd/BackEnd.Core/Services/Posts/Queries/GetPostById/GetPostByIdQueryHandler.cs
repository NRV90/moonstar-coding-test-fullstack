using BackEnd.Core.Interfaces;
using BackEnd.Core.Models;
using BackEnd.Core.Services.Posts.Models;
using BackEnd.Shared.Extensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BackEnd.Core.Services.Posts.Queries.GetPostById
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostApiModel>
    {
        private readonly IPostStore _postStore;

        public GetPostByIdQueryHandler(IPostStore postStore)
        {
            _postStore = postStore.ThrowIfNull(nameof(postStore));
        }

        public async Task<PostApiModel> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            request.ThrowIfNull(nameof(request));

            var post = await _postStore.GetById(request.Id, cancellationToken);

            return ToPostApiModel(post);
        }

        //TODO - implement Automapper or create a mapping service to avoid redundant code.
        private static PostApiModel ToPostApiModel(Post post)
        {
            if (post is null) return null;

            return new PostApiModel()
            {
                Id = post.Id,
                Content = post.Content,
                PhotoUrl = post.PhotoUrl
            };
        }

    }
}
