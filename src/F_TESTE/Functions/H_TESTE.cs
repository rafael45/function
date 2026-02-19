using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace F_TESTE.Functions;

public class H_TESTE
{
    private readonly ILogger _logger;

    public H_TESTE(ILoggerFactory loggerFactory)
        => _logger = loggerFactory.CreateLogger<H_TESTE>();

    [Function("H_TESTE")]
    public void Run(
        [QueueTrigger("h-teste", Connection = "AzureWebJobsStorage")] string message)
    {
        _logger.LogInformation("H_TESTE recebeu: {msg}", message);
    }
}
