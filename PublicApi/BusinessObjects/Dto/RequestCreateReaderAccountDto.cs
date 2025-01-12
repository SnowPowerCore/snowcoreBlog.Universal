namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record RequestCreateReaderAccountDto
{
    public required string Email { get; set; }

    public required string FirstName { get; set; }

    public required string NickName { get; set; }

    public required bool ConfirmedAgreement { get; set; }

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public bool InitialEmailConsent { get; set; } = true;
}