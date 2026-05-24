namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record RequestUserNotifications
{
    public required Guid RequestId { get; init; }

    public required Guid UserId { get; init; }
    
    public string? TargetServiceName { get; init; }
}
