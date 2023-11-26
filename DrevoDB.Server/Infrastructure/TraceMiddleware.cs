using DrevoDB.Core;
using DrevoDB.Server.Infrastructure.Models;

namespace DrevoDB.Server.Infrastructure;

class TraceMiddleware
{
    private RequestDelegate Next { get; }

    public TraceMiddleware(RequestDelegate next)
    {
        this.Next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext,
                                  IDrevoTracer drevoTracer)
    {
        ((DrevoTracer)drevoTracer).Id = Guid.NewGuid();
        await Next(httpContext);
    }
}
