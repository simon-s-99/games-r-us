namespace games_r_us_source.Hubs
{
    public class MessagingDTO
    {
        // This class is only used to send messages to our NotificationsHub
        // since sending multiple parameters to a method via SignalR
        // syntax is either impossible or really janky otherwise. 

        public string UserName { get; set; }
        public string Message { get; set; }

        public MessagingDTO(string userName, string message)
        {
            this.UserName = userName;
            this.Message = message;
        }
    }
}
