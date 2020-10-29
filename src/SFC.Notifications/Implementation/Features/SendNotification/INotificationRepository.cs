using System;
using System.Collections.Generic;

namespace SFC.Notifications.Implementation.Features.SendNotification
{
  internal interface INotificationRepository 
  {
    void Add(string email, string title, string body, DateTime date, string loginName, string notificationType);
  }
}