using System.Security.Claims;

namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record AuthenticationStateDto(ClaimsPrincipal User);