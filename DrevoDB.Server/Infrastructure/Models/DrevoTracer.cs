using DrevoDB.Core;

namespace DrevoDB.Server.Infrastructure.Models;

public class DrevoTracer : IDrevoTracer
{
    public Guid Id { get; set; } = Guid.Empty;
}
