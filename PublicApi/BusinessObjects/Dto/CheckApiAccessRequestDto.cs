namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record CheckApiAccessRequestDto
{
    public required string Path { get; init; }

    public required string Method { get; init; }

    public string? Ip { get; init; }

    public string? CountryCode { get; init; }

    public IReadOnlyCollection<string>? Tags { get; init; }
}