namespace SFC.Accounts.Implementation.Features.CreateAccount
{
  interface IAccountRepository
  {
    void Add(string commandLoginName);
  }
}