using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBDateTime;

internal class DBDateTimeColumnFactory : IDBColumnFactory
{
    public string TypeName => "datetime";
    private IServiceProvider ServiceProvider { get; }

    public DBDateTimeColumnFactory(IServiceProvider serviceProvider)
    {
        this.ServiceProvider = serviceProvider;
    }

    public IDBColumn CrateColumn(string name, IEnumerable<DBColumnParam> columnParams)
    {
        var column = this.ServiceProvider.GetRequiredService<DBDateTimeColumn>();
        column.Name = name;
        //TODO инциализировать columnParams

        return column;
    }
}
