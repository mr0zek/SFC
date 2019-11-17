using System.Collections.Generic;

namespace SFC.Alerts
{
  public interface IAlertRepository
  {
    void Add(Alert alert);
    IEnumerable<Alert> GetAll(string loginName);
    Alert Get(string id, string loginName);
  }
}