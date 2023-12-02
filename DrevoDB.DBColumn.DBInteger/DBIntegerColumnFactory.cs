using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBInteger;

internal class DBIntegerColumnFactory : IDBColumnFactory
{
    public string TypeName => "integer";
    private IServiceProvider ServiceProvider { get; }

    public DBIntegerColumnFactory(IServiceProvider serviceProvider)
    {
        this.ServiceProvider = serviceProvider;
    }

    public IDBColumn CrateColumn(string name, IEnumerable<DBColumnParam> columnParams)
    {
        var column = this.ServiceProvider.GetRequiredService<DBIntegerColumn>();
        column.Name = name;
        //TODO инциализировать columnParams

        return column;
    }
}
