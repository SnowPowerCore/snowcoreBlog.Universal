using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class CheckAuthorDisplayNameNotTakenValidator : AbstractValidator<CheckAuthorDisplayNameNotTakenDto>
{
    public CheckAuthorDisplayNameNotTakenValidator()
    {
        RuleFor(x => x.DisplayName).NotEmpty().Length(3, 64);
    }
}
