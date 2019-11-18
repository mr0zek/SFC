namespace SFC.Accounts.Api
{
  public class AccountReadModel
  {
    public AccountReadModel(string loginName)
    {
      LoginName = loginName;
    }

    public string LoginName { get; set; }
  }
}