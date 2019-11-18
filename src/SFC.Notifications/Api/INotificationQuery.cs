using System.Collections.Generic;

namespace SFC.Notifications.Api
{
  public interface INotificationQuery 
  {
    IEnumerable<NotificationsCountResult> GetSendNotificationsCount(string[] requestLoginNames);
  }
}