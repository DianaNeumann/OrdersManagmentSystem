using Domain.OrderItems;
using Domain.Orders;
using Domain.Providers;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.DataAccess;

public interface IDatabaseContext
{
    DbSet<Order> Orders { get; }
    DbSet<OrderItem> Orderitems { get; }
    DbSet<Provider> Providers { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}