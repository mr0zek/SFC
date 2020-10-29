using System.Collections.Generic;
using Automatonymous;
using Newtonsoft.Json;

namespace SFC.Processes.Implementation.UserRegistration
{
  class UserRegistrationSagaData
  {
    public string Id { get; set; }
    public string Email { get; set; }
    public string LoginName { get; set; }
    public string PasswordHash { get; set; }
    public string ZipCode { get; set; }
    public string BaseUrl { get; set; }

    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }

    [JsonConverter(typeof(StateJSonConverter))]
    public State CurrentState { get; set; }

    [JsonIgnore]
    public static IDictionary<string, State> States { get; set; }
  }
}