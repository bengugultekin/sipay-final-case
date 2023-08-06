using FluentValidation;

namespace ApartmentManagementApi.Application.Admin.UserOperations;

public class CreateUserValidator : AbstractValidator<CreateUser>
{
    public CreateUserValidator() 
    {
        RuleFor(x => x.model.NameSurname).MinimumLength(4);
        RuleFor(x => x.model.Email).MinimumLength(4);
        RuleFor(x => x.model.PhoneNumber).MinimumLength(10);
    }
}
