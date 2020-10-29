using SFC.Accounts.Features.AccountQuery.Contract;

namespace SFC.Accounts.Implementation.Features.AccountQuery
{
  interface IAccountsPerspective
  {
    GetAccountQuery.Response Get(string loginName);

    GetAccountsQuery.Response Search(GetAccountsQuery.Request accountQuery);
  }
}
