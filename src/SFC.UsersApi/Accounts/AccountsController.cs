using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SFC.Infrastructure;
using SFC.Notifications.Api;
using SFC.Processes.Api;
using SFC.Processes.UserRegistration.Contract;

namespace SFC.UserApi.Accounts
{
  [ApiVersion("1.0")]
  [Route("api/[controller]")]
  [ApiController]
  public class AccountsController : Controller
  {
    private readonly ICommandBus _commandBus;
    private readonly IEmailQuery _emailQuery;

    public AccountsController(ICommandBus commandBus, IEmailQuery emailQuery)
    {
      _commandBus = commandBus;
      _emailQuery = emailQuery;
    }

    [HttpPost]
    public IActionResult PostAccount([FromBody]PostAccountModel model)
    {
      string id = Guid.NewGuid().ToString().Replace("-","");

      try
      {
        _commandBus.Send(new RegisterUserCommand()
        {
          Id = id,
          BaseUrl = BaseUrl.Current,
          LoginName = model.LoginName,
          ZipCode = model.ZipCode,
          Email = model.Email,
          Password = model.Password
        });
      }
      catch (LoginNameAlreadyUsedException)
      {
        var mds = new ModelStateDictionary();
        mds.AddModelError("loginName", "Already exists");
        return BadRequest(mds);
      }

      return Created(new Uri($"{BaseUrl.Current}/api/v1.0/confirmations/{id}"),id);
    }

    [HttpGet("{loginName}")]
    public ActionResult<GetAccountModel> GetAccount([FromRoute]string loginName)
    {
      string email = _emailQuery.GetEmail(loginName);
      return Json(new GetAccountModel(loginName, email));
    }
  }
}