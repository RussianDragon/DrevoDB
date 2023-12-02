namespace DrevoDB.DBColumn.Abstractions;

public interface IDBColumnFactory
{
    string TypeName { get; }
    IDBColumn CreateColumn(IServiceProvider serviceProvider, string name, IEnumerable<DBColumnParam> columnParams);
}
