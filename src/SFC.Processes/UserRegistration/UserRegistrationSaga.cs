using System.Linq;
using Automatonymous;
using SFC.Infrastructure;
using SFC.Processes.UserRegistration.Contract;

namespace SFC.Processes.UserRegistration
{
  public class UserRegistrationSaga : AutomatonymousStateMachine<UserRegistrationSagaData>
  {
    private readonly ICommandBus _commandBus;
    private readonly IPasswordHasher _passwordHasher;
    public Event<ConfirmUserCommand> ConfirmUserCommand { get; set; }
    public Event<RegisterUserCommand> RegisterUserCommand { get; set; }
    public State WaitingForConfirmation { get; set; }

    public UserRegistrationSaga(ICommandBus commandBus, IPasswordHasher passwordHasher)
    {
      _commandBus = commandBus;
      _passwordHasher = passwordHasher;
      UserRegistrationSagaData.States = States.ToDictionary(f=>f.Name,f=>f);

      //Initially(
      //  When(RegisterUserCommand)
      //    //.Then(do something)
      //    .TransitionTo(WaitingForConfirmation));


      //During(//some state)
      //  When(// soem event appears)
      //    .Then(// do sth)
      //    .TransitionTo(Final);
    }
  }
}
