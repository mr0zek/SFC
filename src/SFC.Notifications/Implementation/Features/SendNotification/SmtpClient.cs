using System;
using SFC.Notifications.Contract;

namespace SFC.Notifications.Implementation.Features.SendNotification
{
  class SmtpClient : ISmtpClient
  {
    public void Send(string email, string title, string body)
    {
      Console.WriteLine("Email sent to : "+email);
      Console.WriteLine("Title : "+title);
      Console.WriteLine("Body : " + body);
    }
  }
}