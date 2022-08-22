using BackEnd.Core.Interfaces;
using BackEnd.Core.Models;

namespace BackEnd.Infrastructure.Data.Stores
{
    public class PostStore : BaseStore<Post>, IPostStore
    {
        public PostStore(PostDbContext context) : base(context)
        {
        }
    }
}
