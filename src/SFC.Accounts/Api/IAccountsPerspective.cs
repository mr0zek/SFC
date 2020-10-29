namespace SFC.Accounts.Api
{
  public interface IAccountsQuery
  {
    AccountReadModel Get(string loginName);
    AccountsReadModel Search(Api.AccountQuery accountQuery);
  }
}
