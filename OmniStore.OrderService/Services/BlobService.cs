using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace OmniStore.OrderService.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "invoices";

        public BlobService(IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("BlobStorage");
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task<string> UploadInvoiceAsync(int orderId, IFormFile file)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            await containerClient.CreateIfNotExistsAsync(PublicAccessType.None);

            var extension = Path.GetExtension(file.FileName);
            var blobName = $"order-{orderId}-invoice-{Guid.NewGuid()}{extension}";

            var blobClient = containerClient.GetBlobClient(blobName);


            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });
            }

            return blobClient.Uri.ToString();
        }
    }
}
