using Results;

namespace snowcoreBlog.PublicApi;

public sealed record DataResult<TValue>(TValue? Value = default, List<ErrorResultDetail> Errors = default)
{
    public bool IsSuccess => Errors.Count == 0;

    public bool IsFailed => Errors.Count != 0;

    public ErrorResultDetail? Error => Errors.FirstOrDefault();
}