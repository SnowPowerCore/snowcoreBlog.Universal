namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public enum IdempotencyRequestState
{
    /// <summary>The request already finished; it will not be executed again.</summary>
    Completed = 0,

    /// <summary>The request is currently executing under an active lease.</summary>
    InProgress = 1,

    /// <summary>The key exists but something differs (e.g. payload hash) — no execution started.</summary>
    Conflict = 2
}
