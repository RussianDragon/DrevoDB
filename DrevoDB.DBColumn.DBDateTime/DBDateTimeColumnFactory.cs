using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBDateTime;

internal class DBDateTimeColumnFactory : IDBColumnFactory
{
    public string TypeName => "datetime";

    public IDBColumn CreateColumn(IServiceProvider serviceProvider, string name, IEnumerable<DBColumnParam> columnParams)
    {
        var column = serviceProvider.GetRequiredService<DBDateTimeColumn>();
        column.Name = name;
        //TODO инциализировать columnParams

        return column;
    }
}
