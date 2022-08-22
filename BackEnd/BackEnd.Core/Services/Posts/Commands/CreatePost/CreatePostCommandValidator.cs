using BackEnd.Shared.Codes;
using FluentValidation;
using FluentValidation.Results;

namespace BackEnd.Core.Services.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(post => post).Custom((post, context) =>
            {
                if (string.IsNullOrEmpty(post.Content) && string.IsNullOrEmpty(post.PhotoUrl))
                {
                    context.AddFailure(new ValidationFailure($"{nameof(post.PhotoUrl)}-{nameof(post.Content)}", ValidationErrorCodes.InvalidPost));
                }
            });
        }
    }
}
