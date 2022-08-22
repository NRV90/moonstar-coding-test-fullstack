using BackEnd.Core.Services.Posts.Models;
using MediatR;

namespace BackEnd.Core.Services.Posts.Queries.GetPostById
{
    public class GetPostByIdQuery : IRequest<PostApiModel>
    {
        public int Id { get; }

        public GetPostByIdQuery(int id)
        {
            Id = id;
        }
    }
}
