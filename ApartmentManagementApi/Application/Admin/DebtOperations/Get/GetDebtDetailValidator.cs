using FluentValidation;

namespace ApartmentManagementApi.Application.Admin.DebtOperations;

public class GetDebtDetailValidator : AbstractValidator<GetDebtDetail>
{
    public GetDebtDetailValidator() 
    {
        RuleFor(x => x.DebtId).GreaterThan(0);
    } 
}
