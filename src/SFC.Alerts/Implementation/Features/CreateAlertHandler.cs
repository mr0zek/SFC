using System;
using System.Collections.Generic;
using System.Text;
using SFC.Alerts.Contract;
using SFC.Infrastructure;

namespace SFC.Alerts.Implementation.Features
{
  class CreateAlertHandler : ICommandHandler<CreateAlertCommand>
  {
    private readonly IAlertRepository _alertRepository;
    private readonly IEventBus _eventsBus;

    public CreateAlertHandler(IAlertRepository alertRepository, IEventBus eventsBus)
    {
      _alertRepository = alertRepository;
      _eventsBus = eventsBus;
    }

    public void Handle(CreateAlertCommand command)
    {
      _alertRepository.Add(new Alert(command.Id, command.AdresLine1, command.AdresLine2, command.ZipCode, command.LoginName));
      _eventsBus.Publish(new AlertCreatedEvent(command.Id, command.AdresLine1, command.AdresLine2, command.ZipCode, command.LoginName));
    }
  }
}
