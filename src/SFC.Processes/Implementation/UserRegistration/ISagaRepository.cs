namespace SFC.Processes.Implementation.UserRegistration
{
  interface ISagaRepository
  {
    void Save(string id, object data);
    T Get<T>(string id) where T : class;
  }
}