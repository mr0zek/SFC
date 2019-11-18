using System.Collections.Generic;
using SFC.Notifications.Api;

namespace SFC.Notifications.Features.NotificationQuery
{
  public interface INotificationQuery 
  {
    IEnumerable<NotificationsCountResult> GetSendNotificationsCount(string[] requestLoginNames);
  }
}