using DrevoDB.Core;
using DrevoDB.WebApi.Infrastructure.Models;

namespace DrevoDB.WebApi.Infrastructure;

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
