using DrevoDB.DBColumn.Abstractions;

namespace DrevoDB.DBColumn.DBTime;

internal class DBTimeColumn : IDBColumn
{
    public string Name { get; set; } = string.Empty;
}
