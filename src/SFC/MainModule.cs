using Autofac;
using SFC.Accounts;
using SFC.AdminApi;
using SFC.Alerts;
using SFC.Alerts.Implementation;
using SFC.Infrastructure;
using SFC.Notifications;
using SFC.Notifications.Implementation;
using SFC.Processes;
using SFC.Processes.Implementation;
using SFC.UserApi;

namespace SFC
{
  public class MainModule : Module
  {
    private readonly string _connectionString;

    public MainModule(string connectionString)
    {
      _connectionString = connectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterModule(new AutofacAdminApiModule());
      builder.RegisterModule(new AutofacAlertsModule());
      builder.RegisterModule(new AutofacProcessesModule());
      builder.RegisterModule(new AutofacNotificationsModule());
      builder.RegisterModule(new AutofacAccountsModule());
      builder.RegisterModule(new AutofacUserApiModule());
      builder.RegisterModule(new AutofacInfrastructureModule());
    }
  }
}