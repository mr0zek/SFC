using System.Collections.Generic;
using SFC.Infrastructure;

namespace SFC.Accounts.Features.AccountQuery.Contract
{
  public class GetAccountsQuery : IQuery
  {
    public class Request
    {
      public int Skip { get; set; }
      public int Take { get; set; }
    }

    public class Response
    {
      public class AccountReadDTO
      {
        public AccountReadDTO(string loginName)
        {
          LoginName = loginName;
        }

        public string LoginName { get; set; }
      }

      public Response(IEnumerable<AccountReadDTO> accounts)
      {
        Accounts = accounts;
      }

      public IEnumerable<AccountReadDTO> Accounts { get; set; }
    }

  }
}