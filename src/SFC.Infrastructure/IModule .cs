using System;
using System.Collections.Generic;
using System.Text;

namespace SFC.Infrastructure
{
  public interface IModule
  {
    void SendCommand(ICommand command);
    TResponse Query<TResponse, TRequest>(TRequest request);
    void OverrideDependency<TInterface, TImplementation>() where TImplementation : TInterface;
    void OverrideDependency<TInterface, TImplementation>(TImplementation instance) where TImplementation : TInterface;
  }
}
