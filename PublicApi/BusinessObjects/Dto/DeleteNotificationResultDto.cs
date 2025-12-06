namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Result of deleting a notification.
/// </summary>
public record DeleteNotificationResultDto
{
    /// <summary>
    /// Whether the deletion was successful.
    /// </summary>
    public required bool Success { get; init; }
}
