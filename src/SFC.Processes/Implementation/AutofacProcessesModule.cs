using Autofac;
using SFC.Infrastructure;
using SFC.Processes.Implementation.UserRegistration;

namespace SFC.Processes.Implementation
{
  public class AutofacProcessesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
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
    }
  }
}
