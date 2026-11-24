namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Informative (non-error) response returned when a request hits an existing idempotency key.
/// The original business response is intentionally NOT returned — it may embed data tied to the
/// original call's authorization context.
/// </summary>
public record IdempotencyRequestStatusDto(
    IdempotencyRequestState State,
    Guid PersistedRequestId,
    DateTimeOffset OriginalCreatedAt,
    string Message);
