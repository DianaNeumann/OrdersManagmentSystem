using Application.Dto.Orders;

namespace Application.Services.Interfaces;

public interface IOrdersFilterService
{
    IEnumerable<OrderDto> GetOrderByDateRange(DateTime start, DateTime end);
    IEnumerable<OrderDto> GetOrdersSortedByNumber();
    IEnumerable<OrderDto> GetOrdersSortedByProvidrId();
}