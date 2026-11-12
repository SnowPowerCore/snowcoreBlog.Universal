namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>Admin CRUD representation of an API access restriction rule.</summary>
public record ApiAccessRuleDto
{
    public Guid Id { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }

    public bool Enabled { get; init; }

    public int Priority { get; init; }

    public ApiAccessRestrictionActionDto Action { get; init; }

    public IReadOnlyCollection<string> Methods { get; init; } = [];

    /// <summary>
    /// Path patterns. Supports:
    /// - exact prefix match (e.g. "/api/articles")
    /// - wildcard '*' (e.g. "/api/articles/*")
    /// - regex with "regex:" prefix (e.g. "regex:^/api/articles/\d+$")
    /// </summary>
    public IReadOnlyCollection<string> PathPatterns { get; init; } = [];

    public IReadOnlyCollection<string> Tags { get; init; } = [];

    public IReadOnlyCollection<string> IpRanges { get; init; } = [];

    public IReadOnlyCollection<string> RegionCodes { get; init; } = [];

    public Guid? ResponseTemplateId { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public DateTimeOffset? ExpiresAt { get; init; }
}
