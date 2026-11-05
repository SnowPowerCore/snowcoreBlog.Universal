namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Result of creating a goods checkout. The client redirects the buyer to
/// <see cref="CheckoutUrl"/>; the payment status is later polled via
/// <c>GET payments/{id}</c> or received through the <c>PaymentPaid</c> event.
/// </summary>
public record GoodsCheckoutResultDto
{
    /// <summary>Id of the created payment record (also the Checkout client_reference_id).</summary>
    public required Guid PaymentId { get; init; }

    /// <summary>The caller-supplied reference echoed back for convenience.</summary>
    public required string ReferenceId { get; init; }

    /// <summary>Stripe Checkout Session id.</summary>
    public required string CheckoutSessionId { get; init; }

    /// <summary>Stripe-hosted Checkout URL to redirect the buyer to.</summary>
    public required string CheckoutUrl { get; init; }

    /// <summary>UTC timestamp when the Checkout Session expires (defaults ~24h, configurable).</summary>
    public required DateTime ExpiresAt { get; init; }
}
