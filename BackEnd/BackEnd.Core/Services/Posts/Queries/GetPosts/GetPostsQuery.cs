using BackEnd.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace BackEnd.Core.Services.Posts.Queries.GetPosts
{
    public class GetPostsQuery : IRequest<IReadOnlyCollection<Post>>
    {
    }
}
