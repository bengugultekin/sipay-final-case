using FluentValidation;

namespace ApartmentManagementApi.Application.Admin.ApartmentOperations;

public class GetApartmentDetailValidator : AbstractValidator<GetApartmentDetail>
{
    public GetApartmentDetailValidator ()
    {
        RuleFor(x => x.ApartmentId).GreaterThan(0);
    }
}
