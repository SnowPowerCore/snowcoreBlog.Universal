using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class DeleteNotificationValidator : AbstractValidator<DeleteNotificationDto>
{
    public DeleteNotificationValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
