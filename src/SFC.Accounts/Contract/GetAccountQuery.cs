using System.Collections.Generic;
using SFC.Infrastructure;

namespace SFC.Accounts.Features.AccountQuery.Contract
{
  public class GetAccountQuery : IQuery
  {
    public class Request
    {

      public string LoginName { get; set; }

      public Request(string loginName)
      {
        LoginName = loginName;
      }
    }

    public class Response
    {
      public Response(string loginName)
      {
        LoginName = loginName;
      }

      public string LoginName { get; set; }
    }
  }
}