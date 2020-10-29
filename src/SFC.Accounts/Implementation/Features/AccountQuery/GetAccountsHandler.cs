using SFC.Accounts.Features.AccountQuery.Contract;
using SFC.Accounts.Implementation.Features.AccountQuery;
using SFC.Infrastructure;

namespace SFC.Accounts.Implementation.Features.AccountQuery
{
  class GetAccountsHandler : IQueryHandler<GetAccountsQuery.Response, GetAccountsQuery.Request>
  {
    private readonly IAccountsPerspective _perspective;

    public GetAccountsHandler(IAccountsPerspective perspective)
    {
      _perspective = perspective;
    }

    public GetAccountsQuery.Response Handle(GetAccountsQuery.Request request)
    {
      return _perspective.Search(request);
    }
  }
}