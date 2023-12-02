namespace DrevoDB.DBColumn.Abstractions;

public interface IDBColumnFactory
{
    string TypeName { get; }
    IDBColumn CrateColumn(string name, IEnumerable<DBColumnParam> columnParams);
}
