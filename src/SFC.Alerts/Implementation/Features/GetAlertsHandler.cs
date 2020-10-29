using System.Collections.Generic;
using SFC.Alerts.Contract;
using SFC.Infrastructure;

namespace SFC.Alerts.Implementation.Features
{
  class GetAlertsHandler : IQueryHandler<GetAlertsQuery.Response, GetAlertsQuery.Request>
  {
    private readonly IAlertRepository _alertRepository;

    public GetAlertsHandler(IAlertRepository alertRepository)
    {
      _alertRepository = alertRepository;
    }
    
    public GetAlertsQuery.Response Handle(GetAlertsQuery.Request request)
    {
      return new GetAlertsQuery.Response()
      {
        Alerts = _alertRepository.GetAll(request.LoginName)
      };
    }
  }
}