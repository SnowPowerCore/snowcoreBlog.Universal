namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record UpdateApiAccessRuleDto : CreateApiAccessRuleDto
{
    public required Guid Id { get; init; }
}