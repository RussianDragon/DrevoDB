using DrevoDB.DBColumn.Abstractions;
using DrevoDB.DBColumns.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace DrevoDB.DBColumns;

public class ColumnsFactory : IDBColumnsFactory
{
    private Dictionary<string, IDBColumnFactory> ColumnFactories { get; }

    public ColumnsFactory(IEnumerable<IDBColumnFactory> columnFactories)
    {
        this.ColumnFactories = columnFactories.ToDictionary(cf => cf.TypeName.ToLower(CultureInfo.CurrentCulture));
    }
    public IDBColumn CreateColumn(IServiceProvider serviceProvider, string typeName, string name, IEnumerable<DBColumnParam> columnParams)
        => this.ColumnFactories[typeName.ToLower(CultureInfo.CurrentCulture)].CreateColumn(serviceProvider, name, columnParams);
}
