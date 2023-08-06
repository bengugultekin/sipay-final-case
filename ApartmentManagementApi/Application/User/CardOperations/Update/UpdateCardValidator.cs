using FluentValidation;

namespace ApartmentManagementApi.Application.User.CardOperations;

public class UpdateCardValidator : AbstractValidator<UpdateCard>
{
    public UpdateCardValidator () 
    {
        RuleFor(x => x.CardId).GreaterThan(0);
        RuleFor(x => x.model.Number).NotEmpty().GreaterThan(0);
        RuleFor(x => x.model.Cvc).NotEmpty().GreaterThan(0);
    }
}
