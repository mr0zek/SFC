using FluentValidation;

namespace SFC.UserApi.Alerts
{
  public class PostAlertModelValidator : AbstractValidator<PostAlertModel>
  {
    public PostAlertModelValidator()
    {
      RuleFor(f => f.ZipCode).NotNull().NotEmpty();
    }
  }
}