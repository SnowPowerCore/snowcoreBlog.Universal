namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record CreateReaderAccountDto(
    string Email,
    bool ConfirmedAgreement,
    string NickName = "",
    string FirstName = "",
    string LastName = "",
    string PhoneNumber = "",
    bool Subscribed = false);