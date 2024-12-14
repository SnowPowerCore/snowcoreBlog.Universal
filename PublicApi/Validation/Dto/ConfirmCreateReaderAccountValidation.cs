using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class ConfirmCreateReaderAccountValidation : AbstractValidator<ConfirmCreateReaderAccountDto>
{
    public ConfirmCreateReaderAccountValidation()
    {
        RuleFor(x => x.Email).EmailAddress().MinimumLength(3);
        RuleFor(x => x.VerificationToken).NotEmpty();
        RuleFor(x => x.AuthenticatorAttestation).NotNull();
    }
}