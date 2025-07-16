using MaybeResults;

namespace snowcoreBlog.PublicApi.Utilities.DataResult;

public sealed record DataResult<TValue>(TValue? Value = default, IReadOnlyList<NoneDetail>? Errors = default)
{
    public bool IsSuccess => Errors is default(List<NoneDetail>);

    public bool IsFailed => Errors is not default(List<NoneDetail>) && Errors.Count != 0;

    public NoneDetail? Error => Errors?[0];
}