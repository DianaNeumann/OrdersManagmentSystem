using Application.Dto.OrderItems;

namespace Application.Dto.Orders;

public record OrderDto(int Id, string Number, DateTime Date, int ProviderId, IEnumerable<OrderItemDto> OrderItems);

