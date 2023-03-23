using Application.Abstractions.DataAccess;
using Application.Contracts.OrderItems.Commands;
using FluentValidation;

namespace Application.Validation.Validations.OrderItems;

public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItem.Command>
{
    public CreateOrderItemCommandValidator(IDatabaseContext context)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Number cannot be empty");

        RuleFor(x => new {x.Name, x.OrderId})
            .Must(x => context.Orders.Any(
                o => o.Number.Equals(x.Name) != true))
            .WithMessage("Order's number and order item name cannot be equals");
    }
}