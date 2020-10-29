using System.Collections.Generic;
using System.Linq;
using SFC.Accounts.Features.AccountQuery.Contract;
using SFC.Alerts.Contract;
using SFC.Infrastructure;

namespace SFC.AdminApi.Dashboard
{
  class DashboardPerspective : IDashboardPerspective
  {
    private readonly IQueryBus _query;

    public DashboardPerspective(IQueryBus query)
    {
      _query = query;
    }

    public DashboardResult Search(DashboardQueryModel query)
    {
      var results = _query.Query<GetAccountsQuery.Response, GetAccountsQuery.Request>(new GetAccountsQuery.Request()
      {
        Skip = query.Top,
        Take = query.Take
      });

      var entries = results.Accounts.Select(f => new DashboardEntry()
      {
        AlertsCount = _query.Query<GetAlertsQuery.Response, GetAlertsQuery.Request>(new GetAlertsQuery.Request(f.LoginName)).Alerts.Count(),
        LoginName = f.LoginName
      });
      
      
      return new DashboardResult(entries);
    }
  }
}