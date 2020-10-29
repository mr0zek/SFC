using System.Collections.Generic;
using SFC.Alerts.Contract;

namespace SFC.Alerts.Implementation
{
  interface IAlertRepository
  {
    void Add(Alert alert);
    IEnumerable<GetAlertsQuery.Response.AlertDTO> GetAll(string loginName);
    GetAlertQuery.Response.AlertDTO Get(string id, string loginName);
  }
}