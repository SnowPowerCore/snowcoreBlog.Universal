namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Request to create a Stripe Checkout Session for goods/services.
/// <see cref="ReferenceId"/> is an opaque correlation id owned by the consuming service
/// (e.g. an order id) echoed back in the <c>PaymentPaid</c>/<c>PaymentFailed</c> events.
/// </summary>
public record CreateGoodsCheckoutDto
{
    /// <summary>External order/cart reference the payment belongs to (max 200 chars).</summary>
    public required string ReferenceId { get; init; }

    /// <summary>Payment amount in the currency's minor units (e.g. cents); 1999 = 19.99.</summary>
    public required long AmountMinor { get; init; }

    /// <summary>Three-letter ISO currency code, lowercase (e.g. "usd").</summary>
    public required string Currency { get; init; }

    /// <summary>Human-readable description shown on Checkout and receipts (max 300 chars).</summary>
    public required string Description { get; init; }

    /// <summary>Optional buyer e-mail to prefill Checkout; when omitted Checkout collects it.</summary>
    public string? BuyerEmail { get; init; }

    /// <summary>Optional application account id of the buyer (for logged-in purchases).</summary>
    public Guid? BuyerUserId { get; init; }

    /// <summary>Optional success redirect override; must be an absolute https URL.</summary>
    public string? SuccessUrl { get; init; }

    /// <summary>Optional cancel redirect override; must be an absolute https URL.</summary>
    public string? CancelUrl { get; init; }
}
