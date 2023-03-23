using Application.Abstractions.DataAccess;
using Application.Contracts.Orders.Commands;
using FluentValidation;

namespace Application.Validation.Validations.Orders;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrder.Command>
{

    public CreateOrderCommandValidator(IDatabaseContext context)
    {
        RuleFor(x => x.Number)
            .NotEmpty()
            .WithMessage("Number cannot be empty");
        
        RuleFor(x => new {x.Number, x.ProviderId})
            .Must(x => context.Orders.Any(
                o => o.Number.Equals(x.Number) 
                     && o.Provider.Id.Equals(x.ProviderId)) != true)
            .WithMessage("There musn't be 2 orders from the same supplier with the same order numbers");
    }
}