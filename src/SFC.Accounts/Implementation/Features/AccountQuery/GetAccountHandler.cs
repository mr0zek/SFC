using SFC.Accounts.Features.AccountQuery.Contract;
using SFC.Infrastructure;

namespace SFC.Accounts.Implementation.Features.AccountQuery
{
  class GetAccountHandler : IQueryHandler<GetAccountQuery.Response, GetAccountQuery.Request>
  {
    private readonly IAccountsPerspective _perspective;

    public GetAccountHandler(IAccountsPerspective perspective)
    {
      _perspective = perspective;
    }

    public GetAccountQuery.Response Handle(GetAccountQuery.Request request)
    {
      return _perspective.Get(request.LoginName);
    }
  }
}