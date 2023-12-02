using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumns.Abstractions;

public interface IDBColumnsFactory
{
    IDBColumn CreateColumn(IServiceProvider serviceProvider, string typeName, string name, IEnumerable<DBColumnParam> columnParams);
}
