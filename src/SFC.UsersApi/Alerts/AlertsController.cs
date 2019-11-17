using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SFC.Alerts;
using SFC.Alerts.Features.CreateAlert;
using SFC.Alerts.Features.GetAlert;
using SFC.Infrastructure;

namespace SFC.UserApi.Alerts
{
  //[Route("api/v{version:apiVersion}/[controller]")]
  [Route("api/[controller]")]
  [ApiController]
  public class AlertsController : Controller
  {
    [HttpPost]
    public IActionResult Post(PostAlertModel model)
    {
      throw new NotImplemented();
      //return Created($"/api/alerts/{model.Id}", model.Id);
    }

    [HttpGet]
    public IActionResult Get([FromQuery] string loginName)
    {
      throw new NotImplemented();
      //return Json(...);
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] string id, [FromQuery] string loginName)
    {
      throw new NotImplemented();
      //return Json(...);
    }
  }
}