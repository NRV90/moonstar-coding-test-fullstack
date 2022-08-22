using FluentValidation;

namespace BackEnd.Core.Services.Posts.Queries.GetPostById
{
    public class GetPostByIdQueryValidator : AbstractValidator<GetPostByIdQuery>
    {
        public GetPostByIdQueryValidator()
        {
            RuleFor(post => post.Id).GreaterThan(0);
        }
    }
}
