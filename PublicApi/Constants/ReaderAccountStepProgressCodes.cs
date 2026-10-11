namespace snowcoreBlog.PublicApi.Constants;

/// <summary>
/// Stable, machine-readable codes of the meaningful steps of the reader account
/// registration processes. They carry no personal data and are translated into
/// localized messages on the client side.
/// </summary>
public static class ReaderAccountStepProgressCodes
{
    public const string ValidatingEmailDomain = "validating-email-domain";
    public const string CheckingAccountExists = "checking-account-exists";
    public const string CheckingPendingRegistration = "checking-pending-registration";
    public const string CheckingNickNameAvailability = "checking-nick-name-availability";
    public const string CreatingTempUser = "creating-temp-user";
    public const string CreatingUserAccount = "creating-user-account";
    public const string CreatingReaderProfile = "creating-reader-profile";
}
