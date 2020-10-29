using SFC.Infrastructure;

namespace SFC.Accounts.Features.CreateAccount.Contract
{
  public class AccountCreatedEvent : IEvent
  {
    public AccountCreatedEvent(string loginName)
    {
      LoginName = loginName;
    }

    public string LoginName { get; set; }
  }
}
