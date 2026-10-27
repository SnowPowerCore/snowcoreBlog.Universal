namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public enum IdempotencyRequestState
{
    /// <summary>The request already finished; it will not be executed again.</summary>
    Completed = 0,

    /// <summary>The request is currently executing under an active lease.</summary>
    InProgress = 1,

    /// <summary>The key exists but something differs (e.g. payload hash) — no execution started.</summary>
    Conflict = 2
}

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
