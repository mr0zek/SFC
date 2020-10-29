using System;
using System.Collections.Generic;
using System.Text;
using SFC.Infrastructure;
using SFC.Notifications.Contract;

namespace SFC.Notifications.Implementation.Features.NotificationQuery
{
  class NotificationsCountHandler : IQueryHandler<GetNotificationCountQuery.Response, GetNotificationCountQuery.Request>
  {
    private readonly INotificationQueryRepository _notificationRepository;

    public NotificationsCountHandler(INotificationQueryRepository notificationRepository)
    {
      _notificationRepository = notificationRepository;
    }

    public GetNotificationCountQuery.Response Handle(GetNotificationCountQuery.Request request)
    {
      return new GetNotificationCountQuery.Response()
      {
        Counts = _notificationRepository.GetSendNotificationsCount(request.LoginNames)
      };
    }
  }
}
