using FluentValidation;

namespace ApartmentManagementApi.Application.Admin.ApartmentOperations;

public class UpdateApartmentValidator : AbstractValidator<UpdateApartment>
{
    public UpdateApartmentValidator()
    {
        RuleFor(x => x.ApartmentId).GreaterThan(0);
        RuleFor(x => x.model.UserId).GreaterThanOrEqualTo(0);
        RuleFor(x => x.model.Block).MinimumLength(1);
        RuleFor(x => x.model.Type).MinimumLength(3);
        RuleFor(x => x.model.Floor).GreaterThan(0);
        RuleFor(x => x.model.Number).GreaterThan(0);
    }
}
