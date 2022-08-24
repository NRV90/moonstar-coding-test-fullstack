using BackEnd.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace BackEnd.Core.Services.Posts.Queries.GetPosts
{
    public class GetPostsQuery : IRequest<IReadOnlyCollection<Post>>
    {
        public GetPostsQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public int Skip { get; }
        public int Take { get; }
    }
}
