namespace SFC.Notifications.Api
{
  public interface IEmailQuery
  {
    string GetEmail(string loginName);
  }
}