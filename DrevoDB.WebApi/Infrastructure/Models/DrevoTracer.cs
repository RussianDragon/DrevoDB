using DrevoDB.Core;

namespace DrevoDB.WebApi.Infrastructure.Models;

public class DrevoTracer : IDrevoTracer
{
    public Guid Id { get; set; } = Guid.Empty;
}
