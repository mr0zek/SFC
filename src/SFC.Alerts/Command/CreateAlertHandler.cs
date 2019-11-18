using System;
using SFC.Alerts.Api;
using SFC.Infrastructure;

namespace SFC.Alerts.Command
{
  class CreateAlertHandler : ICommandHandler<CreateAlertCommand>
  {
    private readonly IAlertRepository _repository;
    private IEventBus _eventBus;

    public CreateAlertHandler(IAlertRepository repository, IEventBus eventBus)
    {
      _repository = repository;
      _eventBus = eventBus;
    }

    public void Handle(CreateAlertCommand command)
    {
      _repository.Add(new Alert(command.Id, command.AdresLine1, command.AdresLine2, command.ZipCode, command.LoginName));
      _eventBus.Publish(new AlertCreatedEvent(command.Id, command.AdresLine1, command.AdresLine2, command.ZipCode,
        command.LoginName));
    }
  }
}
