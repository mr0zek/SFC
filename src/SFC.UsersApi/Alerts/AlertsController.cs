using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SFC.Alerts;
using SFC.Alerts.Contract;
using SFC.Infrastructure;

namespace SFC.UserApi.Alerts
{
  [ApiVersion("1.0")]
  [Route("api/v1.0/[controller]")]
  [ApiController]
  public class AlertsController : Controller
  {
    private readonly ICommandBus _commandBus;
    private readonly IQueryBus _query;

    public AlertsController(ICommandBus commandBus, IQueryBus query)
    {
      _commandBus = commandBus;
      _query = query;
    }

    [HttpPost]
    public IActionResult Post(PostAlertModel model)
    {
      _commandBus.Send(new CreateAlertCommand(
        model.Id, 
        model.AdresLine1, 
        model.AdresLine2, 
        model.ZipCode, 
        model.LoginName));
      
      return Created($"/api/alerts/{model.Id}",model.Id);
    }

    [HttpGet]
    public IActionResult Get([FromQuery] string loginName)
    {
      return Json(_query.Query< GetAlertsQuery.Response, GetAlertsQuery.Request> (new GetAlertsQuery.Request(loginName)));
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] string id, [FromQuery] string loginName)
    {
      return Json(_query.Query<GetAlertQuery.Response, GetAlertQuery.Request>(new GetAlertQuery.Request(id, loginName)));
    }
  }
}