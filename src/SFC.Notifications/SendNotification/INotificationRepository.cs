using System;

namespace SFC.Notifications.SendNotification
{
  internal interface INotificationRepository 
  {
    void Add(string email, string title, string body, DateTime date, string loginName, string notificationType);
  }
}