using System.Collections.Generic;
using System.Linq;
using SFC.Alerts.Api;

namespace SFC.Alerts.Query
{
  class AlertQuery : IAlertQuery
  {
    private readonly IAlertRepository _repository;

    public AlertQuery(IAlertRepository repository)
    {
      _repository = repository;
    }

    public Api.Alert Get(string id, string loginName)
    {
      return _repository.Get(id, loginName).ToAlert();
    }

    public IEnumerable<Api.Alert> GetAll(string loginName)
    {
      return _repository.GetAll(loginName).Select(f => f.ToAlert());
    }
  }
}