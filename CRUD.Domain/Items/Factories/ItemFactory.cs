using CRUD.Domain.Items.DataStructures;
using CRUD.Domain.Items.Models;
using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;

namespace CRUD.Domain.Items.Factories;

public class ItemFactory : IItemFactory, IAggregateRecreate<Item>
{
    private readonly IDomainEventsManager _domainEventsManager;

    public ItemFactory(IDomainEventsManager domainEventsManager)
    {
        _domainEventsManager = domainEventsManager;
    }

    public Item Create(ItemDataStructure dataStructure)
        => new(dataStructure.Id, _domainEventsManager, dataStructure.Name, dataStructure.Description,
            dataStructure.ExpirationDate);

    public void Init(Item aggregate)
    {
        aggregate.SetDependencies(_domainEventsManager);
    }
}