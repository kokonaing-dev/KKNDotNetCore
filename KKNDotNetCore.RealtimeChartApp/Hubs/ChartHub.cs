using Microsoft.AspNetCore.SignalR;

namespace KKNDotNetCore.RealtimeChartApp.Hubs
{
    public class ChartHub : Hub
    {
        public async Task SeverReceiveMessage(string user, string message)
        {
            await Clients.All.SendAsync("ClientReceiveMessage", user, message);
        }
    }
}
