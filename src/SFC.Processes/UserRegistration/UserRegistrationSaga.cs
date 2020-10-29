using System;
using System.Linq;
using Automatonymous;
using SFC.Accounts.Api;
using SFC.Alerts.Api;
using SFC.Infrastructure;
using SFC.Notifications.Api;
using SFC.Processes.Api;
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

      Initially(
        When(RegisterUserCommand)
          .Then(CopyDataToSaga)
          .Then(SaveNotificationEmail)
          .Then(SendRegistrationNotification)
          .TransitionTo(WaitingForConfirmation));

      During(WaitingForConfirmation,
        When(ConfirmUserCommand)
          .Then(CreateUserAccount)
          .Then(CreateAlert)
          .TransitionTo(Final));
    }

    private void CopyDataToSaga(BehaviorContext<UserRegistrationSagaData, RegisterUserCommand> context)
    {
      context.Instance.BaseUrl = context.Data.BaseUrl;
      context.Instance.LoginName = context.Data.LoginName;
      context.Instance.PasswordHash = _passwordHasher.Hash(context.Data.Password);
      context.Instance.Email = context.Data.Email;
      context.Instance.AddressLine1 = context.Data.AddressLine1;
      context.Instance.AddressLine2 = context.Data.AddressLine2;
      context.Instance.ZipCode = context.Data.ZipCode;
    }

    private void CreateUserAccount(BehaviorContext<UserRegistrationSagaData> context)
    {
      _commandBus.Send(new CreateAccountCommand()
      {
        LoginName = context.Instance.LoginName
      });
    }

    private void CreateAlert(BehaviorContext<UserRegistrationSagaData> context)
    {
      _commandBus.Send(new CreateAlertCommand(
        Guid.NewGuid().ToString(),
        context.Instance.AddressLine1,
        context.Instance.AddressLine2,
        context.Instance.ZipCode,
        context.Instance.LoginName));
    }

    private void SaveNotificationEmail(BehaviorContext<UserRegistrationSagaData> context)
    {
      _commandBus.Send(new SetNotificationEmailCommand()
      {
        Email = context.Instance.Email,
        LoginName = context.Instance.LoginName
      });
    }

    private void SendRegistrationNotification(BehaviorContext<UserRegistrationSagaData> context)
    {
      _commandBus.Send(new SendNotificationCommand()
      {
        LoginName = context.Instance.LoginName,
        Body = $"<a href=\"{context.Instance.BaseUrl}/Confirmation/{context.Instance.Id}\">Click her to confirm</a>",
        Title = "Registration confirmation",
        NotificationType = "RegistrationConfirmation"
      });
    }
  }
}
