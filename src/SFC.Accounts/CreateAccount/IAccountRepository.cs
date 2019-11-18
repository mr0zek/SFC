namespace SFC.Accounts.CreateAccount
{
  internal interface IAccountRepository
  {
    void Add(string commandLoginName);
  }
}