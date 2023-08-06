using FluentValidation;

namespace ApartmentManagementApi.Application.Admin.DebtOperations;

public class CreateDebtValidator : AbstractValidator<CreateDebt>
{
    public CreateDebtValidator() 
    {
        RuleFor(x => x.model.Title).NotEmpty().MaximumLength(4);
        RuleFor(x => x.model.Cost).GreaterThan(0);
    }
}
