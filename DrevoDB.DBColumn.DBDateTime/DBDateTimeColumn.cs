using DrevoDB.DBColumn.Abstractions;

namespace DrevoDB.DBColumn.DBDateTime;

internal class DBDateTimeColumn : IDBColumn
{
    public string Name { get; set; } = string.Empty;
}
