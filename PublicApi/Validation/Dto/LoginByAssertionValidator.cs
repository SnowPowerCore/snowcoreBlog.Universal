using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class LoginByAssertionValidator : AbstractValidator<LoginByAssertionDto>
{
    public LoginByAssertionValidator()
    {
        RuleFor(x => x.Email).EmailAddress().MinimumLength(3);
        RuleFor(x => x.AuthenticatorAssertion).NotNull();
    }
}