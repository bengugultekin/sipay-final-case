using FluentValidation;

namespace ApartmentManagementApi.Application.User;

public class PayBillValidator : AbstractValidator<PayBill>
{
    public PayBillValidator ()
    {
        RuleFor(x => x.model.CardNumber).NotNull().GreaterThan(0);
        RuleFor(x => x.model.CardCvc).NotNull().GreaterThan(0);
        RuleFor(x => x.model.CardOwner).MinimumLength(4);
    }
}
