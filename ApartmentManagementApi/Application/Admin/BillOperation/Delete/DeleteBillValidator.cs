using FluentValidation;

namespace ApartmentManagementApi.Application.Admin.BillOperation;

public class DeleteBillValidator : AbstractValidator<DeleteBill>
{
    public DeleteBillValidator()
    {
        RuleFor(x => x.BillId).GreaterThan(0);
    }
}
