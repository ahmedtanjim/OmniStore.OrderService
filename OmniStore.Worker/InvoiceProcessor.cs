using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace OmniStore.Worker;

public class InvoiceProcessor
{
   
    private readonly ILogger<InvoiceProcessor> _logger;

    public InvoiceProcessor(ILogger<InvoiceProcessor> logger)
    {
        _logger = logger;
    }

    [Function(nameof(InvoiceProcessor))]
    public void Run([BlobTrigger("invoices/{name}", Connection ="BlobConnection")] Stream stream, string name)
    {
        _logger.LogInformation($"OmniStore Worker Triggered!");
        _logger.LogInformation($"File Name: {name}");
        _logger.LogInformation($"File Size: {stream.Length} bytes");

        Thread.Sleep(200);

        _logger.LogInformation($"Invoice {name} processed successfully");
    }
}