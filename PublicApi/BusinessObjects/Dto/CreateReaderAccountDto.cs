﻿namespace snowcoreBlog.PublicApi;

public record CreateReaderAccountDto(
    string Email,
    string Password,
    bool ConfirmedAgreement,
    string NickName = "",
    string FirstName = "",
    string LastName = "",
    string PhoneNumber = "",
    bool Subscribed = false);