namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Request to create a Stripe Checkout Session for a one-time donation.
/// On success the response contains the hosted Checkout URL to redirect to;
/// the donation is confirmed asynchronously via webhooks (see <c>DonationPaid</c>).
/// </summary>
public record CreateDonationCheckoutDto
{
    /// <summary>Donation amount in the currency's minor units (e.g. cents); 500 = 5.00.</summary>
    public required long AmountMinor { get; init; }

    /// <summary>Three-letter ISO currency code, lowercase (e.g. "usd").</summary>
    public required string Currency { get; init; }

    /// <summary>Optional donor e-mail to prefill Checkout; when omitted Checkout collects it.</summary>
    public string? DonorEmail { get; init; }

    /// <summary>Optional application account id of the donor (for logged-in donations).</summary>
    public Guid? DonorUserId { get; init; }

    /// <summary>Optional public thank-you note stored with the donation (max 500 chars).</summary>
    public string? Message { get; init; }

    /// <summary>Optional success redirect override; must be an absolute https URL.</summary>
    public string? SuccessUrl { get; init; }

    /// <summary>Optional cancel redirect override; must be an absolute https URL.</summary>
    public string? CancelUrl { get; init; }
}
