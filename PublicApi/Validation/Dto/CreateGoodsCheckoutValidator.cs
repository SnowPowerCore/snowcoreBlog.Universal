using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class CreateGoodsCheckoutValidator : AbstractValidator<CreateGoodsCheckoutDto>
{
    public CreateGoodsCheckoutValidator()
    {
        RuleFor(x => x.ReferenceId).NotEmpty().MaximumLength(200);
        RuleFor(x => x.AmountMinor).GreaterThan(0).LessThanOrEqualTo(1_000_000_000);
        RuleFor(x => x.Currency).NotEmpty().Length(3);
        RuleFor(x => x.Currency).Must(BeLowerCase)
            .WithMessage("Currency must be a lowercase ISO 4217 code.");
        RuleFor(x => x.Description).NotEmpty().MaximumLength(300);
        RuleFor(x => x.BuyerEmail).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.BuyerEmail));
        RuleFor(x => x.SuccessUrl).Must(BeAValidHttpsUrl).When(x => !string.IsNullOrWhiteSpace(x.SuccessUrl))
            .WithMessage("SuccessUrl must be an absolute https URL");
        RuleFor(x => x.CancelUrl).Must(BeAValidHttpsUrl).When(x => !string.IsNullOrWhiteSpace(x.CancelUrl))
            .WithMessage("CancelUrl must be an absolute https URL");
    }

    private static bool BeLowerCase(string currency) =>
        currency.Equals(currency.ToLowerInvariant(), StringComparison.Ordinal);

    private static bool BeAValidHttpsUrl(string? url)
    {
        if (string.IsNullOrWhiteSpace(url)) return true;
        return Uri.TryCreate(url, UriKind.Absolute, out var uri)
               && uri.Scheme == Uri.UriSchemeHttps;
    }
}
