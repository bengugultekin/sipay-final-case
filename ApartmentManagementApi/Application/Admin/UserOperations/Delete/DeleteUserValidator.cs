using FluentValidation;

namespace ApartmentManagementApi.Application.Admin.UserOperations

{
    public class DeleteUserValidator : AbstractValidator<DeleteUser>
    {
        public DeleteUserValidator() 
        {
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
