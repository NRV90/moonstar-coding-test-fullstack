using MediatR;

namespace BackEnd.Core.Services.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public int Id { get; }

        public DeletePostCommand(int id)
        {
            Id = id;
        }
    }
}
