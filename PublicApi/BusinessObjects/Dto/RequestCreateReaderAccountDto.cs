namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record RequestCreateReaderAccountDto(
    string Email,
    string FirstName,
    string NickName,
    bool ConfirmedAgreement,
    string LastName = "",
    string PhoneNumber = "",
    bool InitialEmailConsent = true);