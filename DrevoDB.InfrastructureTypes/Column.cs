namespace DrevoDB.InfrastructureTypes;

public class Column
{
    public required string Name { get; init; }
    public required ColumnsTypes ColumnsType { get; init; }
}
