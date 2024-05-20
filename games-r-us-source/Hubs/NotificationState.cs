namespace games_r_us_source.Hubs
{
    // Used to pass state to ancestors instead of chaining eventcallbacks
    public class NotificationState
    {
        public NotificationDTO NotificationDTO { get; private set; }

        public void SetNotificationDTO(NotificationDTO notificationDTO)
        {
            this.NotificationDTO = notificationDTO;
            NotifyStateChanged();
        }

        public event Action OnChange;

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}
