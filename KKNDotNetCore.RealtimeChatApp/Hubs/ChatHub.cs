using Microsoft.AspNetCore.SignalR;

namespace KKNDotNetCore.RealtimeChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SeverReceiveMessage(string user, string message)
        {
            await Clients.All.SendAsync("ClientReceiveMessage", user, message);
        }
    }
}
