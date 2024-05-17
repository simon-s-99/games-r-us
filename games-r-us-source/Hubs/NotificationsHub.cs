using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace games_r_us_source.Hubs
{
    public class NotificationsHub : Hub<INotificationClient>
    {
        // Send a test notification when user connect to hub
        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).RecieveNotification(
                "User-message = " + Context.ConnectionId);

            await base.OnConnectedAsync();
        }

        public async Task SendNotification(string message)
        {
            await Clients.All.RecieveNotification(message);
        }
    }

    public interface INotificationClient
    {
        Task RecieveNotification(string message);
    }
}
