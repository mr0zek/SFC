using System;
using SFC.Infrastructure;

namespace SFC.Processes.Contract
{
  public class ConfirmUserCommand : ICommand
  {
    public class LoginNameAlreadyUsedException : Exception
    {
      public string LoginName { get; }

      public LoginNameAlreadyUsedException(string loginName)
      {
        LoginName = loginName;
      }
    }

    public string ConfirmationId { get; set; }
    public bool Confirmed { get; set; }
  }
}