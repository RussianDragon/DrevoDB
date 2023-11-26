using System.Runtime.Serialization;

namespace DrevoDB.Core;

[Serializable]
public class EntityParameter<TEntity> : ISerializable
{
    public bool IsUndefined { get; private set; }
    public bool IsDefined => !this.IsUndefined;
    public TEntity? Value { get; private set; }
    
    public EntityParameter()
    {
        this.IsUndefined = true;
    }

    public EntityParameter(TEntity value)
    {
        this.Value = value;
        this.IsUndefined = false;
    }

    protected EntityParameter(SerializationInfo info, StreamingContext context)
    {
        this.IsUndefined = info.GetBoolean(nameof(IsUndefined));
        this.Value = (TEntity?)info.GetValue(nameof(Value), typeof(TEntity?));
    }

    public override string? ToString()
    {
        return this.Value?.ToString();
    }

    public static implicit operator EntityParameter<TEntity>(TEntity value)
    {
        return new EntityParameter<TEntity>(value);
    }

    public static explicit operator TEntity(EntityParameter<TEntity> value)
    {
        return value.Value!;
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(IsUndefined), IsUndefined);
        info.AddValue(nameof(Value), Value);
    }
}
