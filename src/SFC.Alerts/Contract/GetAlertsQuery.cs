
using System.Collections.Generic;
using SFC.Infrastructure;

namespace SFC.Alerts.Contract
{
  public class GetAlertsQuery : IQuery
  {
    public class Request
    {
      public Request(string loginName)
      {
        LoginName = loginName;
      }

      public string LoginName { get; set; }
    }

    public class Response
    {
      public class AlertDTO
      {
        public string Id { get; }
        public string AdresLine1 { get; }
        public string AdresLine2 { get; }
        public string ZipCode { get; }
        public string LoginName { get; set; }
        public bool Active { get; set; }

        public AlertDTO(string id, string adresLine1, string adresLine2, string zipCode, string loginName)
        {
          Id = id;
          AdresLine1 = adresLine1;
          AdresLine2 = adresLine2;
          ZipCode = zipCode;
          LoginName = loginName;
          Active = true;
        }
      }

      public IEnumerable<AlertDTO> Alerts { get; internal set; }
    }
  }
}