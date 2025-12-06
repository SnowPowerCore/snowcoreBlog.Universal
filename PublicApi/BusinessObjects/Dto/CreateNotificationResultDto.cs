namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Result of creating a notification.
/// </summary>
public record CreateNotificationResultDto
{
    /// <summary>
    /// The ID of the created notification.
    /// </summary>
    public required Guid Id { get; init; }
}
