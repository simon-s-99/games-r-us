namespace games_r_us_source.Components.Notifications
{
    // Used to pass state to ancestors instead of chaining eventcallbacks
    public class NotificationState
    {
        public NotificationDTO NotificationDTO { get; private set; }

        public void SetNotificationDTO(NotificationDTO notificationDTO)
        {
            NotificationDTO = notificationDTO;
            NotifyStateChanged(); // triggers an onchange event when notifications are set
        }

        public event Action<NotificationDTO> OnChange;

        private void NotifyStateChanged()
        {
            OnChange?.Invoke(NotificationDTO);
        }
    }
}
