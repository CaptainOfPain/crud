using CRUD.Domain.Items.Models;
using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;

namespace CRUD.Domain.Items.Events;

public class ItemDeletedEvent : IDomainEvent
{
    public Guid CorrelationId { get; set; }
    public AggregateId Id { get; }

    private ItemDeletedEvent(AggregateId id)
    {
        Id = id;
    }

    public static ItemDeletedEvent Create(Item item)
        => new(item.Id);
}