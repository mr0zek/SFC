using SFC.Infrastructure;

namespace SFC.Notifications.Contract
{
  public class NotificationSentEvent : IEvent
  {
    public string LoginName { get; set; }
    public string Email { get; set; }
    public string NotificationType { get; set; }
  }
}