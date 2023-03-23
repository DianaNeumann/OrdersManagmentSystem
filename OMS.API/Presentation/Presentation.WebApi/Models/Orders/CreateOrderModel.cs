namespace Presentation.WebApi.Models.Orders;

public record CreateOrderModel(string Number, DateTime Date, int ProviderId);
