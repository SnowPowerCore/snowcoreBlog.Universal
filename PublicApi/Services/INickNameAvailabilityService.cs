using ActualLab.Fusion;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

namespace snowcoreBlog.PublicApi.Services;

/// <summary>
/// Real-time nickname availability compute service.
/// <para>
/// Implemented as a Fusion <see cref="IComputeService"/> on the backend
/// (<c>snowcoreBlog.Backend.ReadersManagement</c>) and exposed to clients as a
/// transparent replica via ActualLab.Rpc. The computed result is cached and
/// automatically invalidated whenever a nickname is reserved (e.g. on reader
/// account creation), so every connected client observes the new availability
/// state in real time without manual refresh.
/// </para>
/// <para>
/// Mirrors the legacy REST endpoint
/// <c>POST /api/readers/check/nickname/v1</c> (<c>CheckNickNameNotTakenDto</c>)
/// but returns a richer, UI-friendly <see cref="NickNameAvailability"/>.
/// </para>
/// </summary>
public interface INickNameAvailabilityService : IComputeService
{
    /// <summary>
    /// Returns the cached, real-time availability of <paramref name="nickName"/>.
    /// Recomputed on the server only when the value is invalidated
    /// (see <see cref="NotifyReservedAsync"/>).
    /// </summary>
    /// <param name="nickName">Candidate nickname (already client-normalized, e.g. trimmed).</param>
    /// <param name="cancellationToken">Standard cancellation token.</param>
    [ComputeMethod]
    Task<NickNameAvailability> GetAsync(string nickName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Notifies the compute layer that <paramref name="nickName"/> has been
    /// reserved (or released), triggering cascading invalidation so every
    /// dependent <see cref="GetAsync"/> recomputes on next access.
    /// </summary>
    /// <remarks>
    /// This is a plain (non-computed) command method invoked from the account
    /// creation flow. It is intentionally <b>not</b> exposed over RPC.
    /// </remarks>
    Task NotifyReservedAsync(string nickName, CancellationToken cancellationToken = default);
}
