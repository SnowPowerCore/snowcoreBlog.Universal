namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>Snapshot of a donation as returned by the Stripe microservice.</summary>
public record DonationDto
{
    public required Guid Id { get; init; }

    /// <summary>Donation amount in the currency's minor units.</summary>
    public required long AmountMinor { get; init; }

    /// <summary>Three-letter ISO currency code, lowercase.</summary>
    public required string Currency { get; init; }

    public required StripePaymentStatusDto Status { get; init; }

    /// <summary>Optional public thank-you note written by the donor.</summary>
    public string? Message { get; init; }

    /// <summary>Stripe-hosted receipt URL (present once paid).</summary>
    public string? ReceiptUrl { get; init; }

    public required DateTime CreatedAt { get; init; }

    /// <summary>UTC timestamp when the payment succeeded (null until then).</summary>
    public DateTime? PaidAt { get; init; }
}
