﻿using FluentValidation;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Validation.Dto;

public sealed class RequestAttestationOptionsValidator : AbstractValidator<RequestAttestationOptionsDto>
{
    public RequestAttestationOptionsValidator()
    {
        RuleFor(x => x.Email).EmailAddress().MinimumLength(3);
        RuleFor(x => x.VerificationToken).NotEmpty();
        RuleFor(x => x.AttestationType).NotNull();
        RuleFor(x => x.ResidentKey).NotNull();
        RuleFor(x => x.UserVerification).NotNull();
    }
}