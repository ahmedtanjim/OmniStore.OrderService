using Microsoft.AspNetCore.Http;    
namespace OmniStore.OrderService.Services
{
    public interface IBlobService
    {
        Task<String> UploadInvoiceAsync(int orderID, IFormFile file);
    }
}
