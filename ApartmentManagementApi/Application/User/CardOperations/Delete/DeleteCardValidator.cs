using FluentValidation;

namespace ApartmentManagementApi.Application.User.CardOperations;

public class DeleteCardValidator : AbstractValidator<DeleteCard>
{
    public DeleteCardValidator()
    {
        RuleFor(x => x.CardId).GreaterThan(0);
    }
}
