namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Result of creating a donation checkout. The client redirects the donor to
/// <see cref="CheckoutUrl"/>; the donation status is later polled via
/// <c>GET donations/{id}</c> or received through the <c>DonationPaid</c> event.
/// </summary>
public record DonationCheckoutResultDto
{
    /// <summary>Id of the created donation record (also the Checkout client_reference_id).</summary>
    public required Guid DonationId { get; init; }

    /// <summary>Stripe Checkout Session id.</summary>
    public required string CheckoutSessionId { get; init; }

    /// <summary>Stripe-hosted Checkout URL to redirect the donor to.</summary>
    public required string CheckoutUrl { get; init; }

    /// <summary>UTC timestamp when the Checkout Session expires (defaults ~24h, configurable).</summary>
    public required DateTime ExpiresAt { get; init; }
}
