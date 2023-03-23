using Application.Abstractions.DataAccess;
using Application.Dto.Orders;
using Application.Mapping.Orders;
using Application.Services.Interfaces;

namespace Application.Services.Implementations;

public class OrdersFilterService : IOrdersFilterService
{
    private readonly IDatabaseContext _context;
    
    public OrdersFilterService(IDatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<OrderDto> GetOrderByDateRange(DateTime start, DateTime end)
    {
        return _context.Orders
            .Where(o => o.Date >= start && o.Date <= end)
            .Select(o => o.AsDto())
            .ToArray(); // Forced caste
    }
    
    public IEnumerable<OrderDto> GetOrdersSortedByNumber()
    {
        return _context.Orders
            .OrderBy(order => order.Number)
            .Select(order => order.AsDto())
            .ToArray(); // Forced caste
    }
    
    public IEnumerable<OrderDto> GetOrdersSortedByProvidrId()
    {
        return _context.Orders
            .OrderBy(order => order.Provider.Id)
            .Select(order => order.AsDto())
            .ToArray(); // Forced caste
    }
}