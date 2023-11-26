using DrevoDB.InfrastructureTypes;

namespace DrevoDB.DBTasks.Abstractions;

public interface IDBTaskResult
{
    Column[] Columns { get; }
    IAsyncEnumerable<object[]> Rows();
}
