using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace OmniStore.OrderService.Hubs
{
    [Authorize]
    public class SupportHub : Hub
    {
        public async Task SendMessageToSupport(string orderId, string message)
        {
            await Clients.All.SendAsync("ReceiveSupportMessage", orderId, message);
        }

        public override Task OnConnectedAsync()
        {
            var user = Context.User?.Identity?.Name ?? "Unknown User";
            Console.WriteLine($" {user} connected: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }
    }
}
