namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public class ShortUrlStatsDto
{
    public string Code { get; set; } = string.Empty;

    public string OriginalUrl { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public int? MaxClicksPerWindow { get; set; }

    public int? WindowDurationSeconds { get; set; }

    public ulong ClicksInWindow { get; set; }
}
