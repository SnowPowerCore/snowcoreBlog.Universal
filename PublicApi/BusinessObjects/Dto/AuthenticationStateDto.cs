namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record AuthenticationStateDto(Dictionary<string, string> Claims);