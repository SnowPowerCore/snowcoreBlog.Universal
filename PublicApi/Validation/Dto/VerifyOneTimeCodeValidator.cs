using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class VerifyOneTimeCodeValidator : AbstractValidator<VerifyOneTimeCodeDto>
{
    public VerifyOneTimeCodeValidator()
    {
        RuleFor(x => x.Email).EmailAddress().MinimumLength(3);
        RuleFor(x => x.Code).NotEmpty().Matches(@"^\d{6}$");
    }
}
