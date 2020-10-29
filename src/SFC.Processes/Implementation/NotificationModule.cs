using Autofac;
using SFC.Infrastructure;
using SFC.Processes.Implementation.UserRegistration;

namespace SFC.Processes.Contract
{
  public class NotificationModule : Module
  {
    IContainer _container;

    public NotificationModule()
    {
      ContainerBuilder builder = new ContainerBuilder();
      builder.RegisterType<PasswordHasher>().AsImplementedInterfaces();
      builder.RegisterType<SagaRepository>().AsImplementedInterfaces();

      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(IEventHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(IQueryHandler<,>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      _container = builder.Build();
    }

    public override T GetInstance<T>()
    {
      return _container.Resolve<T>();
    }
  }
}
