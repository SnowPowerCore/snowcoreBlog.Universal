using System.Diagnostics.CodeAnalysis;

namespace snowcoreBlog.PublicApi.Utilities.DataResult;

/// <summary>Defines a result.</summary>
public interface IResult
{
    /// <summary>Gets a collection of errors associated with the result.</summary>
    /// <returns>An <see cref="IReadOnlyCollection{T}"/> of <see cref="IError"/> representing the errors.</returns>
    IReadOnlyCollection<IError> Errors { get; }

    /// <summary>Gets whether the result was successful or not.</summary>
    /// <returns><c>true</c> if the result was successful; otherwise, <c>false</c>.</returns>
    bool IsSuccess();

    /// <summary>Gets whether the result failed or not.</summary>
    /// <returns><c>true</c> if the result failed; otherwise, <c>false</c>.</returns>
    bool IsFailed();

    /// <summary>Gets whether the result failed or not.</summary>
    /// <param name="error">The error of the result.</param>
    /// <returns><c>true</c> if the result failed; otherwise, <c>false</c>.</returns>
    bool IsFailed([MaybeNullWhen(false)] out IError error);

    /// <summary>Checks if the result contains an error of the specific type.</summary>
    /// <typeparam name="TError">The type of error to check for.</typeparam>
    /// <returns><c>true</c> if an error of the specified type is present; otherwise, <c>false</c>.</returns>
    bool HasError<TError>()
        where TError : IError;
}
