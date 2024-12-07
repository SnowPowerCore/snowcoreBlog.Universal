using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class CheckNickNameNotTakenValidation : AbstractValidator<CheckNickNameNotTakenDto>
{
    public CheckNickNameNotTakenValidation()
    {
        RuleFor(x => x.NickName).NotEmpty().Length(3, 30);
    }
}