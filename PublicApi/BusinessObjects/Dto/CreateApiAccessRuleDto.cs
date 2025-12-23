namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public record CreateApiAccessRuleDto
{
    public string? Name { get; init; }

    public string? Description { get; init; }

    public bool Enabled { get; init; } = true;

    public int Priority { get; init; } = 0;

    public ApiAccessRestrictionActionDto Action { get; init; } = ApiAccessRestrictionActionDto.Block;

    public IReadOnlyCollection<string>? Methods { get; init; }

    /// <summary>
    /// Path patterns. Supports:
    /// - exact prefix match (e.g. "/api/articles")
    /// - wildcard '*' (e.g. "/api/articles/*")
    /// - regex with "regex:" prefix (e.g. "regex:^/api/articles/\\d+$")
    /// </summary>
    public IReadOnlyCollection<string>? PathPatterns { get; init; }

    public IReadOnlyCollection<string>? Tags { get; init; }

    public IReadOnlyCollection<string>? IpRanges { get; init; }

    public IReadOnlyCollection<string>? RegionCodes { get; init; }

    public Guid? ResponseTemplateId { get; init; }

    public DateTimeOffset? ExpiresAt { get; init; }
}