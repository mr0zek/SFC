using System;
using System.Collections.Generic;
using System.Text;
using SFC.Alerts.Api;
using SFC.Infrastructure;
using SFC.Notifications.Api;

namespace SFC.Processes.AlertNotification
{
  class AlertNotification : IEventHandler<AlertCreatedEvent>
  {
    private readonly ICommandBus _commandBus;

    public AlertNotification(ICommandBus commandBus)
    {
      _commandBus = commandBus;
    }

    public void Handle(AlertCreatedEvent @event)
    {
      _commandBus.Send(new SendNotificationCommand()
      {
        Title = "Smog alert created",
        Body = $"Smog alert has been succesfuly created, zip code: {@event.ZipCode}",
        LoginName = @event.LoginName,
        NotificationType = "AlertConditionRegistered"
      });

    }
  }
}
