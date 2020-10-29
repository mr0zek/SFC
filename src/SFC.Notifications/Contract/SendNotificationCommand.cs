
using SFC.Infrastructure;

namespace SFC.Notifications.Contract
{
  public class SendNotificationCommand : ICommand
  {
    public string LoginName { get; set; }
    public string Body { get; set; }
    public string Title { get; set; }
    public string NotificationType { get; set; }
  }
}