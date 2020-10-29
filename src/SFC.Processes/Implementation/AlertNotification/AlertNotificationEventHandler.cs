using SFC.Alerts.Contract;
using SFC.Infrastructure;
using SFC.Notifications.Contract;

namespace SFC.Processes.Implementation.AlertNotification
{
  class SmogAlertEventHandler : IEventHandler<AlertCreatedEvent>
  {
    private readonly ICommandBus _commandBus;

    public SmogAlertEventHandler(ICommandBus commandBus)
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
