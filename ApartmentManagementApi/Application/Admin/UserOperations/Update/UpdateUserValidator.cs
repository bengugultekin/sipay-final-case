using FluentValidation;

namespace ApartmentManagementApi.Application.Admin.UserOperations;

public class UpdateUserValidator : AbstractValidator<UpdateUser>
{
    public UpdateUserValidator ()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.model.NameSurname).MinimumLength(4);
        RuleFor(x => x.model.Email).MinimumLength(4);
        RuleFor(x => x.model.PhoneNumber).MinimumLength(10);
    }
}
