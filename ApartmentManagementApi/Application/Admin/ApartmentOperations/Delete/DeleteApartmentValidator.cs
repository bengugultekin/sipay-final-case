using FluentValidation;

namespace ApartmentManagementApi.Application.Admin.ApartmentOperations;

public class DeleteApartmentValidator : AbstractValidator<DeleteApartment>
{
    public DeleteApartmentValidator() 
    {
        RuleFor(x => x.ApartmentId).GreaterThan(0);
    }
}
