namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record RegionRestrictionSnapshotDto
{
    public required Guid Id { get; init; }

    public required string RegionCode { get; init; }

    public required ApiAccessRestrictionActionDto Level { get; init; }

    public required DateTimeOffset CreatedAt { get; init; }

    public DateTimeOffset? ExpiresAt { get; init; }

    public IReadOnlyCollection<string> AffectedPaths { get; init; } = [];
}