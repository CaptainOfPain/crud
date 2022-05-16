using AutoMapper;
using CRUD.Domain.Items.Models;
using CRUD.Domain.Items.Repositories;
using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;
using PlaygroundShared.Infrastructure.Core.Repositories;

namespace CRUD.Infrastructure.Persistence.Items;

public class ItemRepository : BaseAggregateRootRepository<Item, ItemEntity, ItemEventEntity>, IItemRepository
{
    public ItemRepository(IGenericRepository<ItemEntity> repository, IGenericEventRepository<ItemEventEntity> eventRepository, IDomainEventsManager domainEventsManager, IMapper mapper, IAggregateRecreate<Item> aggregateRecreate) : base(repository, eventRepository, domainEventsManager, mapper, aggregateRecreate)
    {
    }
}