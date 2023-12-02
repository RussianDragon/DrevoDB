using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBDate;

public class DBDateColumnFactory : IDBColumnFactory
{
    public string TypeName => "date";

    public IDBColumn CreateColumn(IServiceProvider serviceProvider, string name, IEnumerable<DBColumnParam> columnParams)
    {
        var column = serviceProvider.GetRequiredService<DBDateColumn>();
        column.Name = name;
        //TODO инциализировать columnParams

        return column;
    }
}
