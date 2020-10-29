using Automatonymous;
using SFC.Accounts.Api;
using SFC.Infrastructure;
using SFC.Processes.Api;
using SFC.Processes.UserRegistration.Contract;

namespace SFC.Processes.UserRegistration
{
  class UserRegistrationHandler : ICommandHandler<RegisterUserCommand>
  {
    private readonly ICommandBus _commandBus;
    private readonly ISagaRepository _sagaRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAccountsQuery _accountQuery;

    public UserRegistrationHandler(
      ICommandBus commandBus, 
      ISagaRepository sagaRepository, 
      IPasswordHasher passwordHasher, IAccountsQuery accountQuery)
    {
      _commandBus = commandBus;
      _sagaRepository = sagaRepository;
      _passwordHasher = passwordHasher;
      _accountQuery = accountQuery;
    }

    public void Handle(RegisterUserCommand command)
    {
      if (_accountQuery.Get(command.LoginName) != null)
      {
        throw new LoginNameAlreadyUsedException(command.LoginName);
      }

      if (_sagaRepository.Get<UserRegistrationSagaData>(command.LoginName) != null)
      {
        throw new LoginNameAlreadyUsedException(command.LoginName);
      }

      UserRegistrationSaga saga = new UserRegistrationSaga(_commandBus, _passwordHasher);
      UserRegistrationSagaData data = new UserRegistrationSagaData {Id = command.Id};
      saga.RaiseEvent(data, saga.RegisterUserCommand, command);
      _sagaRepository.Save(data.Id, data);
    }
  }
}