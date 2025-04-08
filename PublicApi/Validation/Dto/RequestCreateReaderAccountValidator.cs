using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;
using snowcoreBlog.PublicApi.Extensions;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class RequestCreateReaderAccountValidator : AbstractValidator<RequestCreateReaderAccountDto>
{
    public RequestCreateReaderAccountValidator()
    {
        RuleFor(x => x.NickName).NotEmpty().Length(3, 30);
        RuleFor(x => x.Email).EmailAddress().MinimumLength(3);
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.PhoneNumber).PhoneShared().When(x => !string.IsNullOrEmpty(x.PhoneNumber));
        RuleFor(x => x.ConfirmedAgreement).Equal(true);
        RuleFor(x => x.InitialEmailConsent).Equal(true);
    }
}