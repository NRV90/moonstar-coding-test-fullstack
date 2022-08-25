using BackEnd.Core.Interfaces;
using BackEnd.Shared.Extensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BackEnd.Core.Services.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IPostStore _postStore;

        public DeletePostCommandHandler(IPostStore postStore)
        {
            _postStore = postStore.ThrowIfNull(nameof(postStore));
        }


        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            request.ThrowIfNull(nameof(request));

            await _postStore.Delete(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}
