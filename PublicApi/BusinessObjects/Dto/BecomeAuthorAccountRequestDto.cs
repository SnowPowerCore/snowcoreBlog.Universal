namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record BecomeAuthorAccountRequestDto(Guid UserId, string DisplayName);
