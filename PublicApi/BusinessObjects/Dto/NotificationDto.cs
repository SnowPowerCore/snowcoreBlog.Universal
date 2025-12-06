namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Represents a top bar technical notification.
/// </summary>
public record NotificationDto
{
    /// <summary>
    /// Unique identifier of the notification.
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// The title/text displayed in the notification bar.
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Optional description or additional message.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Optional URL for more information.
    /// </summary>
    public string? LinkUrl { get; init; }

    /// <summary>
    /// Optional text for the link button/anchor.
    /// </summary>
    public string? LinkText { get; init; }

    /// <summary>
    /// Type of notification for styling purposes.
    /// </summary>
    public required NotificationTypeDto Type { get; init; }

    /// <summary>
    /// Priority for ordering notifications (higher = more important).
    /// </summary>
    public int Priority { get; init; }

    /// <summary>
    /// Whether this notification is currently active.
    /// </summary>
    public bool IsActive { get; init; }

    /// <summary>
    /// Whether this notification can be dismissed by the user.
    /// </summary>
    public bool IsDismissible { get; init; }

    /// <summary>
    /// When this notification becomes active.
    /// </summary>
    public DateTime? StartDate { get; init; }

    /// <summary>
    /// When this notification expires.
    /// </summary>
    public DateTime? EndDate { get; init; }

    /// <summary>
    /// When this notification was created.
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// When this notification was last modified.
    /// </summary>
    public DateTime? ModifiedAt { get; init; }
}
