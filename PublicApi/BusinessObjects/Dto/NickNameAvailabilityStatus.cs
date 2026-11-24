namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Coarse availability status for a nickname candidate.
/// </summary>
public enum NickNameAvailabilityStatus
{
    /// <summary>Nothing to check yet (empty / below minimum length).</summary>
    Idle = 0,

    /// <summary>A check is in flight.</summary>
    Checking = 1,

    /// <summary>The nickname is free to claim.</summary>
    Available = 2,

    /// <summary>The nickname is already claimed or reserved.</summary>
    Taken = 3,

    /// <summary>The nickname failed local/format validation and was not checked.</summary>
    Invalid = 4,
}
