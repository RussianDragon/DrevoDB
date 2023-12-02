using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBText;

internal class DBTextColumnFactory : IDBColumnFactory
{
    public string TypeName => "text";

    public IDBColumn CreateColumn(IServiceProvider serviceProvider, string name, IEnumerable<DBColumnParam> columnParams)
    {
        var column = serviceProvider.GetRequiredService<DBTextColumn>();
        column.Name = name;
        //TODO инциализировать columnParams

        return column;
    }
}
