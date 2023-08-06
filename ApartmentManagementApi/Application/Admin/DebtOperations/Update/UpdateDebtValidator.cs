using FluentValidation;

namespace ApartmentManagementApi.Application.Admin.DebtOperations;

public class UpdateDebtValidator : AbstractValidator<UpdateDebt>
{
    public UpdateDebtValidator()
    {
        RuleFor(x => x.DebtId).GreaterThan(0);
        RuleFor(x => x.model.Title).NotEmpty().MaximumLength(4);
        RuleFor(x => x.model.Cost).GreaterThan(0);
    }
}
