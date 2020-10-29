
namespace SFC.Notifications.Implementation.Features.SetNotificationEmail
{
  internal interface IEmailWriteRepository
  {
    void Set(string loginName, string email);
  }
}
