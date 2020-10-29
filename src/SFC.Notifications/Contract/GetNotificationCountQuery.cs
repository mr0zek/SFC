
using System.Collections.Generic;
using SFC.Infrastructure;

namespace SFC.Notifications.Contract
{
  public class GetNotificationCountQuery : IQuery
  {
    public class Request
    {
      public Request(string[] loginNames)
      {
        LoginNames = loginNames;
      }

      public string[] LoginNames { get; set; }
    }

    public class Response
    {
      public class NotificationsCountResult
      {
        public NotificationsCountResult(string loginName, int count)
        {
          LoginName = loginName;
          Count = count;
        }

        public string LoginName { get; set; }
        public int Count { get; set; }
      }

      public IEnumerable<NotificationsCountResult> Counts { get; set; }
    }
  }
}