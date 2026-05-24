namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record UserNotificationsResponse
{
    public required Guid RequestId { get; init; }

    public required List<NotificationDto> Notifications { get; init; }
    
    public string? SourceService { get; init; }
}
