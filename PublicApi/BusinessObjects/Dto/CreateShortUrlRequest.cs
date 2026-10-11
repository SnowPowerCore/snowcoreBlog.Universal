namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public class CreateShortUrlRequest
{
    public string OriginalUrl { get; set; } = string.Empty;
    public int? MaxClicks { get; set; }
    public int? WindowSeconds { get; set; }
    public string? CustomCode { get; set; }
}
