using Application.Dto.Orders;

namespace Presentation.WebApi.Models.OrderItem;

public record UpdateOrderItemModel(int Id, int OrderId, string Name, decimal Quantity, string Unit);
