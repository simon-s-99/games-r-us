namespace games_r_us_source.Components.Notifications
{
    public class NotificationDTO
    {
        // This class is only used to send messages to our NotificationsHub
        // since sending multiple parameters to a method via SignalR
        // syntax is either impossible or really janky otherwise. 

        public string UserName { get; set; }
        public string Message { get; set; }

        public NotificationDTO(string userName, string message)
        {
            UserName = userName;
            Message = message;
        }
    }
}
