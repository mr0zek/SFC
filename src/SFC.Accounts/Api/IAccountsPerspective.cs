using SFC.Accounts.Api;

namespace SFC.Accounts.Features.AccountQuery
{
  public interface IAccountsQuery
  {
    AccountReadModel Get(string loginName);
    AccountsReadModel Search(Api.AccountQuery accountQuery);
  }
}
