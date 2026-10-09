using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class CreateArticleValidator : AbstractValidator<CreateArticleDto>
{
    public CreateArticleValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(200);

        RuleFor(x => x.Markdown)
            .NotEmpty()
            .MinimumLength(30);

        RuleFor(x => x.Tags)
            .Must(tags => tags is null || tags.Length <= 10)
            .WithMessage("No more than 10 tags are allowed")
            .ForEach(tag => tag.NotEmpty().MaximumLength(50));

        RuleFor(x => x.CoverImageUrl)
            .Must(BeAValidUrl)
            .When(x => !string.IsNullOrWhiteSpace(x.CoverImageUrl))
            .WithMessage("CoverImageUrl must be a valid absolute http(s) URL");

        RuleFor(x => x.Category)
            .MaximumLength(100)
            .When(x => !string.IsNullOrWhiteSpace(x.Category));

        RuleFor(x => x.Excerpt)
            .MaximumLength(500)
            .When(x => !string.IsNullOrWhiteSpace(x.Excerpt));

        RuleFor(x => x.MetaDescription)
            .MaximumLength(300)
            .When(x => !string.IsNullOrWhiteSpace(x.MetaDescription));

        RuleForEach(x => x.Authors)
            .NotEqual(Guid.Empty)
            .When(x => x.Authors is not null);
    }

    private static bool BeAValidUrl(string? url)
    {
        if (string.IsNullOrWhiteSpace(url)) return true;
        return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}
