using Microsoft.AspNetCore.SignalR;
namespace OmniStore.OrderService.Hubs
{
    public class SupportHub : Hub
    {
        public async Task SendMessageToSupport(string orderId, string message)
        {
            await Clients.All.SendAsync("ReceiveSupportMessage", orderId, message);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }
    }
}
