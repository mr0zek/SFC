using Autofac;
using SFC.Infrastructure;
using SFC.Notifications.Implementation.Features.SendNotification;
using SFC.Notifications.Implementation.Infrastructure;

namespace SFC.Notifications.Implementation
{
  public class AutofacNotificationsModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(IEventHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(GetType().Assembly)
        .AsClosedTypesOf(typeof(IQueryHandler<,>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterType<EmailRepository>()
        .AsImplementedInterfaces();

      builder.RegisterType<NotificationRepository>()
        .AsImplementedInterfaces();

      builder.RegisterType<SmtpClient>()
        .AsImplementedInterfaces();

    }
  }
}
