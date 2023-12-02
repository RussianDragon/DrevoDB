using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBText;

internal class DBTextColumnFactory : IDBColumnFactory
{
    public string TypeName => "text";
    private IServiceProvider ServiceProvider { get; }

    public DBTextColumnFactory(IServiceProvider serviceProvider)
    {
        this.ServiceProvider = serviceProvider;
    }

    public IDBColumn CrateColumn(string name, IEnumerable<DBColumnParam> columnParams)
    {
        var column = this.ServiceProvider.GetRequiredService<DBTextColumn>();
        column.Name = name;
        //TODO инциализировать columnParams

        return column;
    }
}
