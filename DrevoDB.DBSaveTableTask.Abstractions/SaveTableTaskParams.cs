namespace DrevoDB.DBSaveTableTask.Abstractions;

public class SaveTableTaskParams
{
    public bool IsNewTable { get; set; }
    public string Name { get; set; } = string.Empty;
}
