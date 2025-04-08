using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class RequestAssertionOptionsValidator : AbstractValidator<RequestAssertionOptionsDto>
{
    public RequestAssertionOptionsValidator()
    {
        RuleFor(x => x.Email).EmailAddress().MinimumLength(3);
        RuleFor(x => x.UserVerification).NotNull();
    }
}