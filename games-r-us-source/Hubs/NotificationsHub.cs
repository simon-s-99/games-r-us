using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace games_r_us_source.Hubs
{
    public class NotificationsHub : Hub<INotificationClient>
    {
        // Send a test notification when user connect to hub
        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).RecieveNotification(
                "User-message = " + Context.ConnectionId +
                " nameid= " /* + Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value*/);

            var omegaTest = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var monkaS = Context.User?.FindFirst(ClaimTypes.Name)?.Value;
            string? user = Context.UserIdentifier;

            await base.OnConnectedAsync();
        }

        public async Task SendNotificationToAll(string message)
        {
            await Clients.All.RecieveNotification(message);
        }

        public async Task SendNotificationTo(string appUserID, string message)
        {
            //HubConnectionContext test = new();
            //var appuserid = Context.User?.Identity.Name;
            var omegaTest = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string? user = Context.UserIdentifier;
            if (user is not null)
            {
                await Clients.User(user).RecieveNotification(message);
            }
        }
    }

    public interface INotificationClient
    {
        Task RecieveNotification(string message);
    }
}
