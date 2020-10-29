using System;
using Automatonymous;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SFC.Processes.Implementation.UserRegistration
{
  class StateJSonConverter : JsonConverter
  {
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      writer.WriteValue(((State)value).Name);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      if (reader.TokenType == JsonToken.Null)
        return null;

      JToken jt = JToken.Load(reader);
      string value = jt.Value<string>();

      return UserRegistrationSagaData.States[value];
    }


    public override bool CanConvert(Type objectType)
    {
      return objectType == typeof(State);
    }
  }
}