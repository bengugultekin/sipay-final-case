using FluentValidation;

namespace ApartmentManagementApi.Application.Admin.BillOperation;

public class UpdateBillValidator : AbstractValidator<UpdateBill>
{
    public UpdateBillValidator()
    {
        RuleFor(x => x.BillId).GreaterThan(0);
        RuleFor(x => x.model.UserId).GreaterThan(0);
        RuleFor(x => x.model.Cost).GreaterThan(0);

    }
}
