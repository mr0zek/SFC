using SFC.Infrastructure;

namespace SFC.Notifications.Contract
{
  public class GetEmailQuery : IQuery
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
      public Response(string email)
      {
        Email = email;
      }

      public string Email { get; set; }
    }
  }
}