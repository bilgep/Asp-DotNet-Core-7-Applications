using Microsoft.AspNetCore.SignalR;

namespace TopBooks8_MinimalAPI.Hubs
{
    public class BookHub : Hub
    {
        public async Task SendMessageToAll(string message)
        {
            await Clients.All.SendAsync("Message", message);
        }
    }
}
