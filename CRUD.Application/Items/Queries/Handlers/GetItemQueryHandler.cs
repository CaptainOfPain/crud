using CRUD.Application.Exceptions;
using CRUD.Application.Items.DTOs;
using CRUD.Domain.Items.Repositories;
using PlaygroundShared.Application.CQRS;

namespace CRUD.Application.Items.Queries.Handlers;

public class GetItemQueryHandler : IQueryHandler<GetItemQuery, ItemDto>
{
    private readonly IItemRepository _itemRepository;

    public GetItemQueryHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    
    public async Task<ItemDto> HandleAsync(GetItemQuery query)
    {
        var item = await _itemRepository.GetAsync(query.Id);
        if (item == null || item.IsArchived)
        {
            throw new NotFoundException("Item not found");
        }

        return ItemDto.From(item);
    }
}