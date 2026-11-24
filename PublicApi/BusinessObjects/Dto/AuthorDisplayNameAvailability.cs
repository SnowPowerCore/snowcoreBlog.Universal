using MemoryPack;

namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Real-time author display name availability result returned by the
/// <see cref="Services.IAuthorDisplayNameAvailabilityService"/> Fusion compute service.
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
