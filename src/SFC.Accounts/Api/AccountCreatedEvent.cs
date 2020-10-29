namespace SFC.Accounts.Api
{
  public class AccountCreatedEvent
  {
    public AccountCreatedEvent(string loginName)
    {
      LoginName = loginName;
    }

    public string LoginName { get; set; }
  }
}
