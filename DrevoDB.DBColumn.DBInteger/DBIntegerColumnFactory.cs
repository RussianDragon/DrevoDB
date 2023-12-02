using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBInteger;

internal class DBIntegerColumnFactory : IDBColumnFactory
{
    public string TypeName => "integer";

    public IDBColumn CreateColumn(IServiceProvider serviceProvider, string name, IEnumerable<DBColumnParam> columnParams)
    {
        var column = serviceProvider.GetRequiredService<DBIntegerColumn>();
        column.Name = name;
        //TODO инциализировать columnParams

        return column;
    }
}
