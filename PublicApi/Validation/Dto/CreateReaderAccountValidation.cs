using FluentValidation;

namespace snowcoreBlog.PublicApi;

public class CreateReaderAccountValidation : AbstractValidator<CreateReaderAccountDto>
{
    public CreateReaderAccountValidation()
    {
        RuleFor(x => x.NickName).NotEmpty();
    }
}