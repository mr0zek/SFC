using System.Collections.Generic;
using static SFC.Notifications.Contract.GetNotificationCountQuery.Response;

namespace SFC.Notifications.Implementation.Features.NotificationQuery
{
  internal interface INotificationQueryRepository 
  {
    IEnumerable<NotificationsCountResult> GetSendNotificationsCount(string[] requestLoginNames);
  }
}