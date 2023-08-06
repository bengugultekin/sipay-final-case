using FluentValidation;

namespace ApartmentManagementApi.Application.User.CardOperations;

public class CreateCardValidator : AbstractValidator<CreateCard>
{
    public CreateCardValidator ()
    {
        RuleFor(x => x.model.Number).NotEmpty().GreaterThan(0);
        RuleFor(x => x.model.Cvc).NotEmpty().GreaterThan(0);
    }
}
