using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class SetupReaderAccountAuthenticatorValidator : AbstractValidator<SetupReaderAccountAuthenticatorDto>
{
    public SetupReaderAccountAuthenticatorValidator()
    {
        RuleFor(x => x.Email).EmailAddress().MinimumLength(3);
        RuleFor(x => x.VerificationToken).NotEmpty();
    }
}
