namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public enum ApiAccessRestrictionActionDto
{
    Block = 0,
    RequireCaptcha = 1,
    AllowWithWarning = 2
}