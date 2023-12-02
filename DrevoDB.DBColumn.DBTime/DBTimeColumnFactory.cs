using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBTime;

internal class DBTimeColumnFactory : IDBColumnFactory
{
    public string TypeName => "time";

    public IDBColumn CreateColumn(IServiceProvider serviceProvider, string name, IEnumerable<DBColumnParam> columnParams)
    {
        var column = serviceProvider.GetRequiredService<DBTimeColumn>();
        column.Name = name;
        //TODO инциализировать columnParams

        return column;
    }
}
