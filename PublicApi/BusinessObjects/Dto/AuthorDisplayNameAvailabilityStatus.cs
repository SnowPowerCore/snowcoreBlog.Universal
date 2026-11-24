namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

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
