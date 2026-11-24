using MemoryPack;

namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Real-time nickname availability result returned by the
/// <see cref="INickNameAvailabilityService"/> Fusion compute service.
/// </summary>
/// <param name="Status">Coarse availability status (idle/checking/available/taken/invalid).</param>
/// <param name="CheckedAt">UTC timestamp the underlying check was performed; null while pending.</param>
[MemoryPackable]
public sealed partial record NickNameAvailability(
    NickNameAvailabilityStatus Status,
    DateTimeOffset? CheckedAt = null)
{
    public static readonly NickNameAvailability Idle =
        new(NickNameAvailabilityStatus.Idle);

    public static NickNameAvailability Checking() =>
        new(NickNameAvailabilityStatus.Checking);

    public static NickNameAvailability Available(DateTimeOffset at) =>
        new(NickNameAvailabilityStatus.Available, at);

    public static NickNameAvailability Taken(DateTimeOffset at) =>
        new(NickNameAvailabilityStatus.Taken, at);
}
