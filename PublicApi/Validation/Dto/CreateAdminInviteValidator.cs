using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public class CreateAdminInviteValidator : AbstractValidator<CreateAdminInviteDto>
{
    public CreateAdminInviteValidator()
    {
        RuleFor(x => x.NickName).NotEmpty().Length(3, 30);
        RuleFor(x => x.Email).EmailAddress().MinimumLength(1);
    }
}