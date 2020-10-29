
using SFC.Infrastructure;

namespace SFC.Notifications.Contract
{
  public class SetNotificationEmailCommand : ICommand
  {
    public string Email { get; set; }
    public string LoginName { get; set; }
  }
}