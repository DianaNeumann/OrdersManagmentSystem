namespace Presentation.WebApi.Models.Orders;

public record UpdateOrderModel(int Id, string Number, DateTime Date, int ProviderId);