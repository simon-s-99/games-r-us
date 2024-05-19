﻿using Microsoft.AspNetCore.Authorization;
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
            var httpContext = Context.GetHttpContext();
            var headerUserName = httpContext.Request.Headers["UserName"].ToString();

            // this is one of 4 approaches recommended by microsoft - this is "Single-user groups"
            // OnConnect we add the users ConnectionId to Groups which is essentially just a Dictionary/Hashmap
            // When the User is disconnected dispose is called on their connection
            // which also removes it from Groups.
            Groups.AddToGroupAsync(Context.ConnectionId, headerUserName);

            await Clients.Client(Context.ConnectionId).RecieveNotificationAsync(
                "User-message = " + Context.ConnectionId);

            await Clients.Client(Context.ConnectionId).RecieveNotificationAsync(
                "User-Name = " + headerUserName);

            await base.OnConnectedAsync();
        }

        public async Task SendNotificationTo(MessagingDTO messagingDTO)
        {
            await Clients.Group(messagingDTO.UserName).RecieveNotificationAsync(messagingDTO.Message);
        }
    }

    public interface INotificationClient
    {
        Task RecieveNotificationAsync(string message);
    }
}
