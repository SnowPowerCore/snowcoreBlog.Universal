namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record IpRestrictionSnapshotDto
{
    public required Guid Id { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }

    public required bool IsBlocked { get; init; }

    public required DateTimeOffset CreatedAt { get; init; }

    public DateTimeOffset? ExpiresAt { get; init; }

    public IReadOnlyCollection<string> IpRanges { get; init; } = [];
}