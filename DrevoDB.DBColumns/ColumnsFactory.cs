using DrevoDB.DBColumn.Abstractions;
using DrevoDB.DBColumns.Abstractions;
using System.Globalization;

namespace DrevoDB.DBColumns;

public class ColumnsFactory : IDBColumnsFactory
{
    private Dictionary<string, IDBColumnFactory> ColumnFactories { get; }

    public ColumnsFactory(IEnumerable<IDBColumnFactory> columnFactories)
    {
        this.ColumnFactories = columnFactories.ToDictionary(cf => cf.TypeName.ToLower(CultureInfo.CurrentCulture));
    }
    public IDBColumn CreateColumn(string typeName, string name, IEnumerable<DBColumnParam> columnParams)
        => this.ColumnFactories[typeName.ToLower(CultureInfo.CurrentCulture)].CrateColumn(name, columnParams);
}
