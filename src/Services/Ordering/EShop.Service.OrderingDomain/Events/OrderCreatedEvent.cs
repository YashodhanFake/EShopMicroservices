namespace EShop.Service.OrderingDomain.Events
{
    public record OrderCreatedEvent(Order order) : IDomainEvent
    {
    }
}
