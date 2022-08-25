using BackEnd.Core.Interfaces;
using BackEnd.Core.Models;
using BackEnd.Core.Services.Posts.Commands.CreatePost;
using BackEnd.Core.Services.Posts.Models;
using BackEnd.Shared.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackEnd.Core.Services.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, PostApiModel>
    {
        private readonly IPostStore _postStore;

        public UpdatePostCommandHandler(IPostStore postStore)
        {
            _postStore = postStore.ThrowIfNull(nameof(postStore));
        }

        public async Task<PostApiModel> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postStore.Update(ToPostModel(request), cancellationToken);

            return ToPostApiModel(post);
        }

        private static Post ToPostModel(UpdatePostCommand request)
        {
            return new Post()
            {
                Id = request.Post.Id,
                Content = request.Post.Content,
                PhotoUrl = request.Post.PhotoUrl
            };
        }

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
