namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Request to delete a notification.
/// </summary>
public record DeleteNotificationDto
{
    /// <summary>
    /// The ID of the notification to delete.
    /// </summary>
    public required Guid Id { get; init; }
}
