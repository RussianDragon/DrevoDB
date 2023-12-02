namespace DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

public interface IDBColumnFactory
{
    string TypeName { get; }
    IDBColumn CreateColumn(IServiceProvider serviceProvider, string name, IEnumerable<DBColumnParam> columnParams);
}
