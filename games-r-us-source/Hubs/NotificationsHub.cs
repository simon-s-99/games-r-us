using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace games_r_us_source.Hubs
{
    //[Authorize] // <-- might need to remove this if program crashes 
    public class NotificationsHub : Hub<INotificationClient>
    {
        // Send a test notification when user connect to hub
        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).RecieveNotificationAsync(
                "User-message = " + Context.ConnectionId);

            await base.OnConnectedAsync();
        }

        public async Task SendNotification(string message)
        {
            await Clients.All.RecieveNotificationAsync(message);
        }
    }

    public interface INotificationClient
    {
        Task RecieveNotificationAsync(string message);
    }
}
