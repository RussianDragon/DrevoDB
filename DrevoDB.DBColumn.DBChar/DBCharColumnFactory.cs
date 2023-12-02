using DrevoDB.DBColumn.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.DBColumn.DBChar;

internal class DBCharColumnFactory : IDBColumnFactory
{
    public string TypeName => "char";
    private IServiceProvider ServiceProvider { get; }

    public DBCharColumnFactory(IServiceProvider serviceProvider)
    {
        this.ServiceProvider = serviceProvider;
    }

    public IDBColumn CrateColumn(string name, IEnumerable<DBColumnParam> columnParams)
    {
        var column = this.ServiceProvider.GetRequiredService<DBCharColumn>();
        column.Name = name;
        //TODO инциализировать columnParams

        return column;
    }
}
