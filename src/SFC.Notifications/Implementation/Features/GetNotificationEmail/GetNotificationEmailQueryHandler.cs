using System;
using System.Collections.Generic;
using System.Text;
using SFC.Infrastructure;
using SFC.Notifications.Contract;
using SFC.Notifications.Implementation.Features.SendNotification;

namespace SFC.Notifications.Implementation.Features.GetNotificationEmail
{
  class GetNotificationEmailQueryHandler : IQueryHandler<GetEmailQuery.Response, GetEmailQuery.Request>
  {
    private readonly IEmailReadRepository _repository;

    public GetNotificationEmailQueryHandler(IEmailReadRepository repository)
    {
      _repository = repository;
    }

    public GetEmailQuery.Response Handle(GetEmailQuery.Request request)
    {
      return new GetEmailQuery.Response(_repository.GetEmail(request.LoginName));
    }
  }
}
