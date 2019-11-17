using System;
using SFC.Alerts.Api;
using SFC.Infrastructure;

namespace SFC.Alerts.Command
{
  class CreateAlertHandler : ICommandHandler<CreateAlertCommand>
  {
    private readonly IAlertRepository _repository;

    public CreateAlertHandler(IAlertRepository repository)
    {
      _repository = repository;
    }

    public void Handle(CreateAlertCommand command)
    {
      _repository.Add(new Alert(command.Id, command.AdresLine1, command.AdresLine2, command.ZipCode, command.LoginName));
    }
  }
}
