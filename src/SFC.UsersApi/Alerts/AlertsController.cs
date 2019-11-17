using System;
using Microsoft.AspNetCore.Mvc;

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
      throw new NotImplementedException();
      //return Created($"/api/alerts/{model.Id}", model.Id);
    }

    [HttpGet]
    public IActionResult Get([FromQuery] string loginName)
    {
      throw new NotImplementedException();
      //return Json(...);
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] string id, [FromQuery] string loginName)
    {
      throw new NotImplementedException();
      //return Json(...);
    }
  }
}