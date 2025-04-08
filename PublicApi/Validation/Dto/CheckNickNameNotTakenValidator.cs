using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class CheckNickNameNotTakenValidator : AbstractValidator<CheckNickNameNotTakenDto>
{
    public CheckNickNameNotTakenValidator()
    {
        RuleFor(x => x.NickName).NotEmpty().Length(3, 30);
    }
}