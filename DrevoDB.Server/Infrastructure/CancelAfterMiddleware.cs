using DrevoDB.Server.Settings;

namespace DrevoDB.Server.Infrastructure;

class CancelAfterMiddleware
{
    private RequestDelegate Next { get; }
    public CancelAfterMiddleware(RequestDelegate next)
    {
        this.Next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, WebApiSettings webAppSettings)
    {
        CancellationTokenSource source = CancellationTokenSource.CreateLinkedTokenSource(httpContext.RequestAborted);
        source.CancelAfter(webAppSettings.InsideActionTimeout);
        httpContext.RequestAborted = source.Token;
        
        await Next(httpContext);
    }
}
