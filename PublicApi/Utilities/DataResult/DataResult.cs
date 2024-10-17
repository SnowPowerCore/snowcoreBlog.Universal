using Results;

namespace snowcoreBlog.PublicApi.Utilities.DataResult;

public sealed record DataResult<TValue>(TValue? Value = default, List<ErrorResultDetail> Errors = default)
{
    public bool IsSuccess => Errors is default(List<ErrorResultDetail>);

    public bool IsFailed => Errors is not default(List<ErrorResultDetail>) && Errors.Count != 0;

    public ErrorResultDetail? Error => Errors?.FirstOrDefault();
}