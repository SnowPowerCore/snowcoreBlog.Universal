using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class CreateReaderAccountValidation : AbstractValidator<CreateReaderAccountDto>
{
    public CreateReaderAccountValidation()
    {
        RuleFor(x => x.NickName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.ConfirmedAgreement).Equal(true);
    }
}