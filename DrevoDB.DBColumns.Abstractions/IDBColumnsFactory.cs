using DrevoDB.DBColumn.Abstractions;

namespace DrevoDB.DBColumns.Abstractions;

public interface IDBColumnsFactory
{
    IDBColumn CreateColumn(IServiceProvider serviceProvider, string typeName, string name, IEnumerable<DBColumnParam> columnParams);
}
