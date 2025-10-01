using System;

namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public record CreateArticleResultDto
{
    public required Guid Id { get; init; }
    public required string Slug { get; init; }
}
