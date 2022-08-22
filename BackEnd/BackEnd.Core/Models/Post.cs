using BackEnd.Shared.Models;

namespace BackEnd.Core.Models
{
    public class Post : BaseEntity
    {
        public string Content { get; set; }
        public string PhotoUrl { get; set; }
    }
}