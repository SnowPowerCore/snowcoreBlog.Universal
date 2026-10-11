namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Lifecycle status of a document. Mirrors
/// <c>snowcoreBlog.Backend.Core.Entities.Documents.DocumentStatus</c>.
/// </summary>
public enum DocumentStatusDto
{
    Uploaded = 0,
    Processing = 1,
    Processed = 2,
    Rejected = 3
}
