using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class RequestCreateReaderAccountValidation : AbstractValidator<RequestCreateReaderAccountDto>
{
    public RequestCreateReaderAccountValidation()
    {
        RuleFor(x => x.NickName).NotEmpty().Length(3, 30);
        RuleFor(x => x.Email).EmailAddress().MinimumLength(3);
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.ConfirmedAgreement).Equal(true);
        RuleFor(x => x.InitialEmailConsent).Equal(true);
    }
}