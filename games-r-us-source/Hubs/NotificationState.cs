namespace games_r_us_source.Hubs
{
    // Used to pass state to ancestors instead of chaining eventcallbacks
    public class NotificationState
    {
        public NotificationDTO NotificationDTO { get; private set; }

        public void SetNotificationDTO(NotificationDTO notificationDTO)
        {
            this.NotificationDTO = notificationDTO;
            NotifyStateChanged(); // triggers an onchange event when notifications are set
        }

        public event Action<NotificationDTO> OnChange;

        private void NotifyStateChanged()
        {
            OnChange?.Invoke(this.NotificationDTO);
        }
    }
}
