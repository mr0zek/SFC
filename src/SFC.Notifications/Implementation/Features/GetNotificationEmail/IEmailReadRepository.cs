namespace SFC.Notifications.Implementation.Features.GetNotificationEmail
{
  internal interface IEmailPerspective
  {
    string GetEmail(string loginName);
  }
}