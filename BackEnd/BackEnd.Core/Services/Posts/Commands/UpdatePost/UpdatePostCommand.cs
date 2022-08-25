using BackEnd.Core.Models;
using BackEnd.Core.Services.Posts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.Services.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<PostApiModel>
    {
        public UpdatePostCommand(PostApiModel post)
        {
            Post = post;
        }
        public PostApiModel Post { get; }
    }
}
