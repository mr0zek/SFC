
namespace SFC.Notifications.SetNotificationEmail
{
  internal interface IEmailWriteRepository
  {
    void Set(string loginName, string email);
  }
}
