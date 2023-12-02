using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBDate;

public class DBDateColumnFactory : IDBColumnFactory
{
    public string TypeName => "date";
    private IServiceProvider ServiceProvider { get; }

    public DBDateColumnFactory(IServiceProvider serviceProvider)
    {
        this.ServiceProvider = serviceProvider;
    }

    public IDBColumn CrateColumn(string name, IEnumerable<DBColumnParam> columnParams)
    {
        var column = this.ServiceProvider.GetRequiredService<DBDateColumn>();
        column.Name = name;
        //TODO инциализировать columnParams

        return column;
    }
}
