using FluentValidation;

namespace snowcoreBlog.PublicApi;

public sealed class CreateReaderAccountValidation : AbstractValidator<CreateReaderAccountDto>
{
    public CreateReaderAccountValidation()
    {
        RuleFor(x => x.NickName).NotEmpty();
    }
}