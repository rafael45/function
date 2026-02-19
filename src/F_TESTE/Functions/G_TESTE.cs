using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace F_TESTE.Functions
{
    public class G_TESTE
    {
        private readonly ILogger<G_TESTE> _logger;

        public G_TESTE(ILogger<G_TESTE> logger)
        {
            _logger = logger;
        }

        [Function(nameof(G_TESTE))]
        public void Run(
            [QueueTrigger("g-teste", Connection = "AzureWebJobsStorage")] string message)
        {
            _logger.LogInformation("G_TESTE recebeu: {Message}", message);
        }
    }
}
