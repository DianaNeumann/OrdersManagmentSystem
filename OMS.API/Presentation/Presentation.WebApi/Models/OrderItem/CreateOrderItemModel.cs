namespace Presentation.WebApi.Models.OrderItem;

public record CreateOrderItemModel(int OrderId, string Name, decimal Quantity, string Unit);