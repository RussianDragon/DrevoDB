using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DrevoDB.SQLClient.Controllers;

[ApiController, Route("[controller]")]
public class SQLClientController : ControllerBase
{
    private IServiceProvider Provider { get; }
    private SQLService SQLService => this.Provider.GetRequiredService<SQLService>();
    public SQLClientController(IServiceProvider provider)
    {
        this.Provider = provider;
    }

    [HttpPost("[action]")]
    public Task<Models.JsonResult> GetJson([FromBody] Requests.JsonRequest request, CancellationToken cancellationToken)
        => this.SQLService.GetJson(request, cancellationToken);
}
