using AutoMapper;
using CRUD.Domain.Items.Models;
using Newtonsoft.Json;
using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;

namespace CRUD.Infrastructure.Persistence.Items;

public class ItemMappings : Profile
{
    public ItemMappings()
    {
        CreateMap<Item, ItemEntity>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id.Id));

        CreateMap<ItemEntity, Item>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => new AggregateId(x.Id)));
        
        
        CreateMap<IDomainEvent, ItemEventEntity>()
            .ForMember(x => x.Id, opt => opt.MapFrom(x => Guid.NewGuid()))
            .ForMember(x => x.AggregateId, opt => opt.MapFrom(x => x.Id.ToGuid()))
            .ForMember(x => x.Event, opt => opt.MapFrom(x => JsonConvert.SerializeObject(x)))
            .ForMember(x => x.CorrelationId, opt => opt.MapFrom(x => x.CorrelationId))
            .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => DateTime.UtcNow))
            .ForMember(x => x.EventType, opt => opt.MapFrom(x => x.GetType().FullName));

    }
}