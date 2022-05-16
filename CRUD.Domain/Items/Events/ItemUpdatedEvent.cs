using CRUD.Domain.Items.Models;
using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;

namespace CRUD.Domain.Items.Events;

public class ItemUpdatedEvent : IDomainEvent
{
    public AggregateId Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime? ExpirationDate { get; }
    public Guid CorrelationId { get; set; }

    private ItemUpdatedEvent(AggregateId id, string name, string description, DateTime? expirationDate)
    {
        Id = id;
        Name = name;
        Description = description;
        ExpirationDate = expirationDate;
    }

    public static ItemUpdatedEvent Create(Item item)
        => new ItemUpdatedEvent(item.Id, item.Name, item.Description, item.ExpirationDate);

}