namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record ApiAccessResponseTemplateSnapshotDto
{
    public required Guid Id { get; init; }

    public string? Name { get; init; }

    public required int StatusCode { get; init; }

    public required string ContentType { get; init; }

    public string? BodyJson { get; init; }

    public string? Reason { get; init; }

    public required DateTimeOffset CreatedAt { get; init; }
}