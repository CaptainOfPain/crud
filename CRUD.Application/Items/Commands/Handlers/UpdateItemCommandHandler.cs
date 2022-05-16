using CRUD.Application.Exceptions;
using CRUD.Domain.Items.Repositories;
using PlaygroundShared.Application.CQRS;

namespace CRUD.Application.Items.Commands.Handlers;

public class UpdateItemCommandHandler : ICommandHandler<UpdateItemCommand>
{
    private readonly IItemRepository _itemRepository;

    public UpdateItemCommandHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    
    public async Task HandleAsync(UpdateItemCommand command)
    {
        var item = (await _itemRepository.GetAsync(command.Id)) ?? throw new NotFoundException("Item not found");
        item.Update(command.Name, command.Description, command.ExpirationDate);

        await _itemRepository.PersistAsync(item);
    }
}