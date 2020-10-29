using System.Collections.Generic;
using System.Linq;
using SFC.Accounts.Features.AccountQuery.Contract;
using SFC.Accounts.Implementation.Features.AccountQuery;
using SFC.Accounts.Implementation.Features.CreateAccount;

namespace SFC.Accounts.Implementation.Infrastructure
{
  class AccountsRepository : IAccountsPerspective, IAccountRepository
  {
    private static readonly List<string> _items = new List<string>();

    GetAccountQuery.Response IAccountsPerspective.Get(string loginName)
    {
      return _items.Where(f => f == loginName)
        .Select(f => new GetAccountQuery.Response(f)).FirstOrDefault();
    }

    public GetAccountsQuery.Response Search(GetAccountsQuery.Request accountQuery)
    {
      return new GetAccountsQuery.Response(
        _items
          .Skip(accountQuery.Skip)
          .Take(accountQuery.Take)
          .Select(f => new GetAccountsQuery.Response.AccountReadDTO(f)));
    }

    public void Add(string loginName)
    {
      _items.Add(loginName);
    }
  }
}