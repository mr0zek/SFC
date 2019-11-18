namespace SFC.Accounts.Api
{
  public interface IAccountQuery
  {
    AccountReadModel Get(string loginName);
    AccountsReadModel Search(AccountQuery accountQuery);
  }
}
