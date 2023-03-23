using Application.Abstractions.DataAccess;
using Application.Contracts.OrderItems.Commands;
using FluentValidation;

namespace Application.Validations.OrderItems;

public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItem.Command>
{
    public CreateOrderItemCommandValidator(IDatabaseContext context)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Number cannot be empty");

        RuleFor(x => new {x.Name, x.OrderId})
            .Must(o => o.Name.Equals(o.OrderId.ToString()) != true)
            .WithMessage("Order's number and order item name cannot be equals");
    }
}