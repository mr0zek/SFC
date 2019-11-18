
namespace SFC.Notifications.SendNotification
{
  internal interface IEmailReadRepository
  {
    string GetEmail(string loginName);
  }
}