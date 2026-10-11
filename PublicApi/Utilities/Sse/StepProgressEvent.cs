namespace snowcoreBlog.PublicApi.Utilities.Sse;

/// <summary>
/// A generic, non-identifying payload of a single step progress update
/// pushed to the client while a stepified process is being executed.
/// <para>
/// <see cref="Step"/> is a stable, machine-readable step code that carries no
/// personal data; the client is responsible for turning it into a localized message.
/// </para>
/// </summary>
public sealed record StepProgressEvent(string Step);
