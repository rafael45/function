using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

public class F_TESTE
{
    private readonly ILogger _logger;

    public F_TESTE(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<F_TESTE>();
    }

    [Function("F_TESTE")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("F_TESTE triggered.");
        var res = req.CreateResponse(HttpStatusCode.OK);
        res.WriteString("OK");
        return res;
    }
}
