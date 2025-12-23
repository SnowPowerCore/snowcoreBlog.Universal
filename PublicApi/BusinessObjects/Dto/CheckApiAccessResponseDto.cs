namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record CheckApiAccessResponseDto
{
    public required bool IsAllowed { get; init; }

    public Guid? MatchedRuleId { get; init; }

    public ApiAccessRestrictionActionDto? Action { get; init; }

    public string? Reason { get; init; }

    public int? StatusCode { get; init; }

    public string? ContentType { get; init; }

    /// <summary>
    /// JSON string to write directly to the HTTP response body when blocked.
    /// </summary>
    public string? BodyJson { get; init; }
}