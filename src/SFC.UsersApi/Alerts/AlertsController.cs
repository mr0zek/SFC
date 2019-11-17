using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SFC.Alerts;
using SFC.Alerts.Api;
using SFC.Infrastructure;
using Alert = SFC.Alerts.Alert;

namespace SFC.UserApi.Alerts
{
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiController]
  public class AlertsController : Controller
  {
    private readonly IAlertQuery _alertQuery;
    private readonly ICommandBus _commandBus;

    public AlertsController(IAlertQuery alertQuery, ICommandBus commandBus)
    {
      _alertQuery = alertQuery;
      _commandBus = commandBus;
    }

    [HttpPost]
    public IActionResult Post(PostAlertModel model)
    {
      _commandBus.Send(new CreateAlertCommand(model.Id, model.AdresLine1, model.AdresLine2, model.ZipCode, model.LoginName));

      return Created($"/api/alerts/{model.Id}", model.Id);
    }

    [HttpGet]
    public IActionResult Get([FromQuery] string loginName)
    {
      return Json(_alertQuery.GetAll(loginName));
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] string id, [FromQuery] string loginName)
    {
      return Json(_alertQuery.Get(id, loginName));
    }
  }
}