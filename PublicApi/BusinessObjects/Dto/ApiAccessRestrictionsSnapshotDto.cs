namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record ApiAccessRestrictionsSnapshotDto
{
    public required DateTimeOffset GeneratedAt { get; init; }

    public IReadOnlyList<ApiAccessRuleSnapshotDto> Rules { get; init; } = [];

    public IReadOnlyList<ApiAccessResponseTemplateSnapshotDto> ResponseTemplates { get; init; } = [];

    public IReadOnlyList<IpRestrictionSnapshotDto> IpRestrictions { get; init; } = [];

    public IReadOnlyList<RegionRestrictionSnapshotDto> RegionRestrictions { get; init; } = [];
}