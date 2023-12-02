using DrevoDB.DBColumn.Abstractions;

namespace DrevoDB.DBColumn.DBText;

internal class DBTextColumn : IDBColumn
{
    public string Name { get; set; } = string.Empty;
}
