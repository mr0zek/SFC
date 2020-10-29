
namespace SFC.Notifications.Implementation.Features.SendNotification
{
  internal interface IEmailReadRepository
  {
    string GetEmail(string loginName);
  }
}