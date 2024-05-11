namespace snowcoreBlog.TelemetryHandling.Interfaces;

public interface ITelemetryService
{
    void TrackException(Exception exception, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null);

    void TrackEvent(string eventName, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null);
}