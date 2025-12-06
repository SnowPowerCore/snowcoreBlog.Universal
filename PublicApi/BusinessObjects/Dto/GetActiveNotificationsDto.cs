namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Request to get active notifications for the top bar.
/// </summary>
public record GetActiveNotificationsDto
{
    /// <summary>
    /// Maximum number of notifications to return.
    /// </summary>
    public int? MaxCount { get; init; }
}
