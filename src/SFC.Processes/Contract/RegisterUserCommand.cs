using SFC.Infrastructure;

namespace SFC.Processes.Contract
{
  public class RegisterUserCommand : ICommand
  {
    public string LoginName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ZipCode { get; set; }
    public string BaseUrl { get; set; }
    public string Id { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
  }
}