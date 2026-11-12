namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>Admin CRUD representation of a blocked-response template.</summary>
public record ApiAccessResponseTemplateDto
{
    public Guid Id { get; init; }

    public string? Name { get; init; }

    public int StatusCode { get; init; }

    public string ContentType { get; init; } = "application/json";

    /// <summary>
    /// JSON string to write directly to the HTTP response body when blocked.
    /// </summary>
    public string? BodyJson { get; init; }

    public string? Reason { get; init; }

    public DateTimeOffset CreatedAt { get; init; }
}
