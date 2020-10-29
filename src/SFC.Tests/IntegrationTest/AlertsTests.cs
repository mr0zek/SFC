using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Configuration;
using RestEase;
using SFC.Infrastructure;
using SFC.Tests.IntegrationTest.Mocks;
using SFC.Tests.IntegrationTest.UserApi;
using Xunit;

namespace SFC.Tests.IntegrationTest
{
  public class AlertsTests 
  {
    private const string _url = "http://localhost:5000";

    [Fact]
    public async void Post_on_alert_resource_should_create_alert_when_not_exists()
    {
      // Setup
      TestEventBus eventBus = new TestEventBus();
      Bootstrap.Run(new string[0], builder =>
      {
        builder.RegisterType<TestSmtpClient>().AsImplementedInterfaces();
        builder.RegisterInstance(eventBus).AsImplementedInterfaces();
      });


      PostAlertModel postAlert = new PostAlertModel()
      {
        Id = Guid.NewGuid().ToString(),
        AdresLine1 = "ul Szkolna 12",
        AdresLine2 = "Gniezno",
        ZipCode = "12-345",
        LoginName = "ala.makotowska"
      };

      // Act
      await RestClient.For<IAlertsApi>(_url).PostAlert(postAlert);

      // Assert
      GetAlertModel getAlert = await RestClient.For<IAlertsApi>(_url).GetAlert(postAlert.Id,"ala.makotowska");

      Assert.Equal(postAlert.AdresLine1, getAlert.AdresLine1);
      Assert.Equal(postAlert.AdresLine2, getAlert.AdresLine2);
      Assert.Equal(postAlert.Id, getAlert.Id);
      Assert.Equal(postAlert.ZipCode, getAlert.ZipCode);
      Assert.True(getAlert.Active);
      Assert.Single(eventBus.PublishedEvents);
    }

    [Fact]
    public async void Post_on_alert_resource_should_return_validation_exception()
    {
      // Setup
      Bootstrap.Run(new string[0], builder => { });
      
      PostAlertModel postAlert = new PostAlertModel()
      {
        Id = Guid.NewGuid().ToString(),
        AdresLine1 = "ul Szkolna 12",
        AdresLine2 = "Gniezno"
      };

      // Act, Assert
      ApiException exception = await Assert.ThrowsAsync<ApiException>(async () => await RestClient.For<IAlertsApi>(_url).PostAlert(postAlert));
      Assert.True(exception.StatusCode == HttpStatusCode.BadRequest);
    }
  }

  public class TestEventBus : IEventBus
  {
    public List<object> PublishedEvents = new List<object>();
    public void Publish<T>(T @event)
    {
      PublishedEvents.Add(@event);
    }
  }
}