namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record CheckAuthorDisplayNameNotTakenDto
{
    public required string DisplayName { get; set; }
}
