using FluentValidation;

namespace ApartmentManagementApi.Application.Admin.BillOperation;

public class GetBillDetailValidator : AbstractValidator<GetBillDetail>
{
    public GetBillDetailValidator()
    {
        RuleFor(x => x.BillId).GreaterThan(0);
    }
}
