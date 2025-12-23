namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record ApiAccessRuleSnapshotDto
{
    public required Guid Id { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }

    public required bool Enabled { get; init; }

    public required int Priority { get; init; }

    public required ApiAccessRestrictionActionDto Action { get; init; }

    public required DateTimeOffset CreatedAt { get; init; }

    public DateTimeOffset? ExpiresAt { get; init; }

    public IReadOnlyCollection<string> Methods { get; init; } = [];

    public IReadOnlyCollection<string> PathPatterns { get; init; } = [];

    public IReadOnlyCollection<string> Tags { get; init; } = [];

    public IReadOnlyCollection<string> IpRanges { get; init; } = [];

    public IReadOnlyCollection<string> RegionCodes { get; init; } = [];

    public Guid? ResponseTemplateId { get; init; }
}