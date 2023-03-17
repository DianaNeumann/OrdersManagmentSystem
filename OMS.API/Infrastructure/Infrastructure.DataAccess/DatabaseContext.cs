using Application.Abstractions.DataAccess;
using Domain.OrderItems;
using Domain.Orders;
using Domain.Providers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess;

internal sealed class DatabaseContext : DbContext, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Order> Orders { get; private init; } = null!;
    public DbSet<OrderItem> Orderitems { get; private init; } = null!;
    public DbSet<Provider> Providers { get; private init; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);
    }
}