using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class ConfirmCreateReaderAccountWithAuthenticatorValidator : AbstractValidator<ConfirmCreateReaderAccountWithAuthenticatorDto>
{
    public ConfirmCreateReaderAccountWithAuthenticatorValidator()
    {
        RuleFor(x => x.Email).EmailAddress().MinimumLength(3);
        RuleFor(x => x.VerificationToken).NotEmpty();
        RuleFor(x => x.Code).NotEmpty().Matches(@"^\d{6}$");
    }
}
