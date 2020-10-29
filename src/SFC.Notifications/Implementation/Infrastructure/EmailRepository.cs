using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using SFC.Notifications.Implementation.Features.GetNotificationEmail;
using SFC.Notifications.Implementation.Features.SendNotification;
using SFC.Notifications.Implementation.Features.SetNotificationEmail;

namespace SFC.Notifications.Implementation.Infrastructure
{
  class EmailRepository : IEmailReadRepository, IEmailWriteRepository, IEmailPerspective
  {
    private static readonly Dictionary<string, string> _items = new Dictionary<string, string>()
    {
      { "User123", "ala.makotowska@gmail.com" }
    };

    public void Set(string loginName, string email)
    {
      _items[loginName] = email;
    }

    public string GetEmail(string loginName)
    {
      return _items[loginName];
    }
  }
}
