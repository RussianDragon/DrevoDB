namespace DrevoDB.SQLClient.Models;

public record JsonResult
{
    public required TimeSpan RequestElapsed { get; init; }
    public required Dictionary<string, TimeSpan> Profile { get; init; }
    public TimeSpan ElapsedTime { get; set; }
    public required Dictionary<string, object>[][] Result { get; init; }
}
