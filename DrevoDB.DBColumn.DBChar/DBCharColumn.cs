using DrevoDB.DBColumn.Abstractions;

namespace DrevoDB.DBColumn.DBChar;

internal class DBCharColumn : IDBColumn
{
    public string Name { get; set; } = string.Empty;
}
