using System.Threading.Tasks;
using RestEase;

namespace SFC.Tests.IntegrationTest.UserApi
{
  public interface IAlertsApi
  {
    [Post("api/v1.0/alerts")]
    Task<string> PostAlert([Body]PostAlertModel account);

    [Get("api/v1.0/alerts/{alertId}")]
    Task<GetAlertModel> GetAlert([Path] string alertId, [Query]string loginName);
  }
}