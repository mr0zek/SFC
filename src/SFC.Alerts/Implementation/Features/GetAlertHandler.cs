using SFC.Alerts.Contract;
using SFC.Infrastructure;

namespace SFC.Alerts.Implementation.Features
{
  class GetAlertHandler : IQueryHandler<GetAlertQuery.Response, GetAlertQuery.Request>
  {
    private readonly IAlertRepository _alertRepository;

    public GetAlertHandler(IAlertRepository alertRepository)
    {
      _alertRepository = alertRepository;
    }

    public GetAlertQuery.Response Handle(GetAlertQuery.Request request)
    {
      return new GetAlertQuery.Response()
      {
        Alert = _alertRepository.Get(request.Id, request.LoginName)
      };
    }
  }
}