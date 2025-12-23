namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record UpdateApiAccessResponseTemplateDto : CreateApiAccessResponseTemplateDto
{
    public required Guid Id { get; init; }
}