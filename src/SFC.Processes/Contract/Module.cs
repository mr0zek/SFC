using SFC.Infrastructure;

namespace SFC.Processes.Contract
{
  public abstract class Module : IModule
  {
    public Module()
    {      
    }

    public void RegisterCommand<TCommand>(TCommand command) where TCommand : ICommand
    {

    }

    public abstract T GetInstance<T>();

    public abstract void OverrideDependency<TInterface, TImplementation>() where TImplementation : TInterface;
    
    public abstract void OverrideDependency<TInterface, TImplementation>(TImplementation instance)where TImplementation : TInterface;     
    
    public TResponse Query<TResponse, TRequest>(TRequest request)
    {
      throw new System.NotImplementedException();
    }

    public void SendCommand(ICommand command)
    {
      throw new System.NotImplementedException();
    }
  }
}