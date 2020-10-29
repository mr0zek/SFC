using System.Collections.Generic;
using System.Linq;
using SFC.Alerts.Contract;

namespace SFC.Alerts.Implementation
{
  class AlertRepository : IAlertRepository
  {
    private static readonly List<Alert> _items = new List<Alert>();

    public void Add(Alert alert)
    {
      _items.Add(alert);
    }

    public IEnumerable<GetAlertsQuery.Response.AlertDTO> GetAll(string loginName)
    {
      return _items.Where(f => f.LoginName == loginName).Select(f =>
      new GetAlertsQuery.Response.AlertDTO(
          f.Id, f.AdresLine1, f.AdresLine2, f.ZipCode, f.LoginName));
    }

    public GetAlertQuery.Response.AlertDTO Get(string id, string loginName)
    {
      var a = _items.First(f => f.Id == id && f.LoginName == loginName);
      return new GetAlertQuery.Response.AlertDTO(
        a.Id, a.AdresLine1, a.AdresLine2, a.ZipCode, a.LoginName);
    }
  }
}