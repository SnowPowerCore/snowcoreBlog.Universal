namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>Snapshot of a goods payment as returned by the Stripe microservice.</summary>
public record PaymentDto
{
    public required Guid Id { get; init; }

    /// <summary>The caller-supplied external reference (order/cart id).</summary>
    public required string ReferenceId { get; init; }

    /// <summary>Human-readable description of the purchased goods.</summary>
    public required string Description { get; init; }

    /// <summary>Payment amount in the currency's minor units.</summary>
    public required long AmountMinor { get; init; }

    /// <summary>Three-letter ISO currency code, lowercase.</summary>
    public required string Currency { get; init; }

    public required StripePaymentStatusDto Status { get; init; }

    /// <summary>Stripe-hosted receipt URL (present once paid).</summary>
    public string? ReceiptUrl { get; init; }

    public required DateTime CreatedAt { get; init; }

    /// <summary>UTC timestamp when the payment succeeded (null until then).</summary>
    public DateTime? PaidAt { get; init; }
}
