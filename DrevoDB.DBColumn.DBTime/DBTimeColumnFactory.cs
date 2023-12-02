using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBTime;

internal class DBTimeColumnFactory : IDBColumnFactory
{
    public string TypeName => "time";
    private IServiceProvider ServiceProvider { get; }

    public DBTimeColumnFactory(IServiceProvider serviceProvider)
    {
        this.ServiceProvider = serviceProvider;
    }

    public IDBColumn CrateColumn(string name, IEnumerable<DBColumnParam> columnParams)
    {
        var column = this.ServiceProvider.GetRequiredService<DBTimeColumn>();
        column.Name = name;
        //TODO инциализировать columnParams

        return column;
    }
}
