using CRUD.Application.Exceptions;
using CRUD.Domain.Items.Repositories;
using PlaygroundShared.Application.CQRS;

namespace CRUD.Application.Items.Commands.Handlers;

public class DeleteItemCommandHandler : ICommandHandler<DeleteItemCommand>
{
    private readonly IItemRepository _itemRepository;

    public DeleteItemCommandHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    
    public async Task HandleAsync(DeleteItemCommand command)
    {
        var item = (await _itemRepository.GetAsync(command.Id)) ?? throw new NotFoundException("Item not found");
        item.MarkAsArchived();

        await _itemRepository.PersistAsync(item);
    }
}