using BackEnd.Core.Interfaces;
using BackEnd.Core.Models;
using BackEnd.Shared.Extensions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BackEnd.Core.Services.Posts.Queries.GetPosts
{
    public class GetPostQueryHandler : IRequestHandler<GetPostsQuery, IReadOnlyCollection<Post>>
    {
        private readonly IPostStore _postStore;

        public GetPostQueryHandler(IPostStore postStore)
        {
            _postStore = postStore.ThrowIfNull(nameof(postStore));
        }

        public async Task<IReadOnlyCollection<Post>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            request.ThrowIfNull(nameof(request));

            return await _postStore.Get(cancellationToken);
        }
    }
}
