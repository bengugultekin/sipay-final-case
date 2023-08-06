using FluentValidation;

namespace ApartmentManagementApi.Application.Admin.DebtOperations;

public class DeleteDebtValidator : AbstractValidator<DeleteDebt>
{
    public DeleteDebtValidator()
    {
        RuleFor(x => x.DebtId).GreaterThan(0);
    }
}
