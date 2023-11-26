namespace DrevoDB.InfrastructureTypes;

public enum ColumnsTypes
{
    None = 0,

    #region String
    Text = 1,
    LongText = 2,
    #endregion

    #region Numbers
    Integer = 3,
    #endregion

    #region Date and time
    DateTime = 4,
    Date = 5,
    Time = 6,
    #endregion
}
