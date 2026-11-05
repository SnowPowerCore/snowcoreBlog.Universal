namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Lifecycle of a Stripe-backed payment as exposed to clients. Mirrors
/// the backend <c>StripePaymentStatus</c> entity enum.
/// </summary>
public enum StripePaymentStatusDto
{
    /// <summary>Checkout session created, waiting for the payer.</summary>
    Pending = 0,

    /// <summary>Payment submitted, asynchronous confirmation pending.</summary>
    Processing = 1,

    /// <summary>Payment confirmed by Stripe.</summary>
    Succeeded = 2,

    /// <summary>Payment failed or expired without completion.</summary>
    Failed = 3,

    /// <summary>Payer abandoned the checkout session.</summary>
    Canceled = 4,

    /// <summary>Payment was (fully) refunded.</summary>
    Refunded = 5
}
