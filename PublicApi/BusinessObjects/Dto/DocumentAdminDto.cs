namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Stored document metadata row for the admin portal search
/// (no download URL — the admin links to the public download route).
/// </summary>
public record DocumentAdminDto
{
    public required Guid Id { get; init; }

    public string FileName { get; init; } = string.Empty;

    public string ContentType { get; init; } = string.Empty;

    public long SizeBytes { get; init; }

    public string Category { get; init; } = string.Empty;

    public DocumentStatusDto Status { get; init; }

    public string Checksum { get; init; } = string.Empty;

    public Guid? OwnerId { get; init; }

    public DateTimeOffset UploadedAt { get; init; }
}
