using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class LoginByAssertionValidation : AbstractValidator<LoginByAssertionDto>
{
    public LoginByAssertionValidation()
    {
        RuleFor(x => x.Email).EmailAddress().MinimumLength(3);
        RuleFor(x => x.AuthenticatorAssertion).NotNull();
    }
}