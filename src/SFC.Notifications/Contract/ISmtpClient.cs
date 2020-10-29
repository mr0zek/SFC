using SFC.Infrastructure;

namespace SFC.Notifications.Contract
{
  public interface ISmtpClient : IInjection
  {
    void Send(string email, string title, string body);
  }
}