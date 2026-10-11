namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Metadata of a stored document as returned by the Documents service.
/// The binary content itself is fetched via <see cref="DownloadUrl"/>.
/// </summary>
public class DocumentDto
{
    public Guid Id { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string ContentType { get; set; } = string.Empty;

    public long SizeBytes { get; set; }

    public string Category { get; set; } = string.Empty;

    public DocumentStatusDto Status { get; set; }

    /// <summary>Hex-encoded SHA-256 hash of the content (deduplication identity).</summary>
    public string Checksum { get; set; } = string.Empty;

    public Guid? OwnerId { get; set; }

    /// <summary>Absolute URL to download the binary content.</summary>
    public string DownloadUrl { get; set; } = string.Empty;

    public Dictionary<string, string>? Metadata { get; set; }

    public DateTime UploadedAt { get; set; }

    public DateTime? ProcessedAt { get; set; }
}
