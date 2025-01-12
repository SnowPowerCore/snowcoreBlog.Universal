namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record CheckNickNameNotTakenDto
{
    public required string NickName { get; set; }
}