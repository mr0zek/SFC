using SFC.Infrastructure;

namespace SFC.Accounts.Features.CreateAccount.Contract
{
  public partial class CreateAccountCommand : ICommand
  {
    public string LoginName { get; set; }
  }
}
