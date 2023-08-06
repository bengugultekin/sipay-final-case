﻿using FluentValidation;

namespace ApartmentManagementApi.Application.Admin.BillOperation;

public class CreateBillValidator : AbstractValidator<CreateBill>
{
    public CreateBillValidator() 
    {
        RuleFor(x => x.model.UserId).GreaterThan(0);
        RuleFor(x => x.model.Cost).GreaterThan(0);
    }
}
