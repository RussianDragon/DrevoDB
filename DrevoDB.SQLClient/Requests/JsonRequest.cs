namespace DrevoDB.SQLClient.Requests;

public class JsonRequest
{
    public bool ProfilerIsActive  { get; set; }
    public string Query { get; set; } = string.Empty;
}
