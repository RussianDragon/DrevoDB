using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBChar;

internal class DBCharColumnFactory : IDBColumnFactory
{
    public string TypeName => "char";

    public IDBColumn CreateColumn(IServiceProvider serviceProvider, string name, IEnumerable<DBColumnParam> columnParams)
    {
        var column = serviceProvider.GetRequiredService<DBCharColumn>();
        column.Name = name;
        //TODO инциализировать columnParams

        return column;
    }
}
