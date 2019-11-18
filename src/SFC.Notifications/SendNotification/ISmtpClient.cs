
namespace SFC.Notifications.SendNotification
{
  public interface ISmtpClient
  {
    void Send(string email, string title, string body);
  }
}