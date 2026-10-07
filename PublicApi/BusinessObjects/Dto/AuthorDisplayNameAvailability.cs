using MemoryPack;

namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Real-time author display name availability result returned by the
/// <see cref="PublicApi.Services.IAuthorDisplayNameAvailabilityService"/> Fusion compute service.
/// </summary>
/// <param name="Status">Coarse availability status (idle/checking/available/taken/invalid).</param>
/// <param name="CheckedAt">UTC timestamp the underlying check was performed; null while pending.</param>
[MemoryPackable]
public sealed partial record AuthorDisplayNameAvailability(
    AuthorDisplayNameAvailabilityStatus Status,
    DateTimeOffset? CheckedAt = null)
{
    public static readonly AuthorDisplayNameAvailability Idle =
        new(AuthorDisplayNameAvailabilityStatus.Idle);

    public static AuthorDisplayNameAvailability Checking() =>
        new(AuthorDisplayNameAvailabilityStatus.Checking);

    public static AuthorDisplayNameAvailability Available(DateTimeOffset at) =>
        new(AuthorDisplayNameAvailabilityStatus.Available, at);

    public static AuthorDisplayNameAvailability Taken(DateTimeOffset at) =>
        new(AuthorDisplayNameAvailabilityStatus.Taken, at);
}

/// <summary>
/// Coarse availability status for an author display name candidate.
/// </summary>
public enum AuthorDisplayNameAvailabilityStatus
{
    /// <summary>Nothing to check yet (empty / below minimum length).</summary>
    Idle = 0,

    /// <summary>A check is in flight.</summary>
    Checking = 1,

    /// <summary>The display name is free to claim.</summary>
    Available = 2,

    /// <summary>The display name is already claimed by another author.</summary>
    Taken = 3,

    /// <summary>The display name failed local/format validation and was not checked.</summary>
    Invalid = 4,
}
