namespace DrevoDB.DBSaveDatabaseTask.Abstractions
{
    public class SaveDatabaseTaskParams
    {
        public bool IsNewDatabase { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}