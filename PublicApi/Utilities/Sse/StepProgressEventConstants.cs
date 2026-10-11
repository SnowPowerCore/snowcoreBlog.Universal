namespace snowcoreBlog.PublicApi.Utilities.Sse;

/// <summary>
/// Defines the name of the server-sent event that carries intermediate
/// step progress updates for a long-running process.
/// </summary>
public static class StepProgressEventConstants
{
    /// <summary>
    /// The event name for intermediate step progress updates.
    /// </summary>
    public const string StepProgressEvent = "step-progress";

    /// <summary>
    /// The event name for the final result of the process. It is always the last
    /// event in the stream (unless the stream was aborted mid-way).
    /// </summary>
    public const string FinalResultEvent = "final-result";
}
