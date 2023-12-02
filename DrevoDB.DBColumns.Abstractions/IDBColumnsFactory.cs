using DrevoDB.DBColumn.Abstractions;

namespace DrevoDB.DBColumns.Abstractions;

public interface IDBColumnsFactory
{
    IDBColumn CreateColumn(string typeName, string name, IEnumerable<DBColumnParam> columnParams);
}
