using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class ConfirmCreateReaderAccountValidator : AbstractValidator<ConfirmCreateReaderAccountDto>
{
    public ConfirmCreateReaderAccountValidator()
    {
        RuleFor(x => x.Email).EmailAddress().MinimumLength(3);
        RuleFor(x => x.VerificationToken).NotEmpty();
        RuleFor(x => x.AuthenticatorAttestation).NotNull();
    }
}