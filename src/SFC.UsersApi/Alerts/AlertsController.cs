using Microsoft.AspNetCore.Mvc;

namespace SFC.UserApi.Alerts
{
  //[Route("api/v{version:apiVersion}/[controller]")]
  [Route("api/[controller]")]
  [ApiController]
  public class AlertsController : Controller
  {
    private IAlertRepository _alertRepository;

    public AlertsController(IAlertRepository alertRepository)
    {
      _alertRepository = alertRepository;
    }

    [HttpPost]
    public IActionResult Post(PostAlertModel model)
    {
      _alertRepository.Add(new Alert(model.Id, model.AdresLine1, model.AdresLine2, model.ZipCode, model.LoginName));

      return Created($"/api/alerts/{model.Id}", model.Id);
    }

    [HttpGet]
    public IActionResult Get([FromQuery] string loginName)
    {
      return Json(_alertRepository.GetAll(loginName));
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] string id, [FromQuery] string loginName)
    {
      return Json(_alertRepository.Get(id, loginName));
    }
  }
}