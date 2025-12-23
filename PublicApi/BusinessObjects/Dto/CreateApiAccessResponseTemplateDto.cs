namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public record CreateApiAccessResponseTemplateDto
{
    public string? Name { get; init; }

    public int StatusCode { get; init; } = 403;

    public string ContentType { get; init; } = "application/json";

    public string? BodyJson { get; init; }

    public string? Reason { get; init; }
}