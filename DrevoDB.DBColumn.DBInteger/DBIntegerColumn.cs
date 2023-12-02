using DrevoDB.DBColumn.Abstractions;

namespace DrevoDB.DBColumn.DBInteger;

public class DBIntegerColumn : IDBColumn
{
    public string Name { get; set; } = string.Empty;
}
