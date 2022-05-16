using CRUD.Application.Exceptions;
using CRUD.Domain.Items.DataStructures;
using CRUD.Domain.Items.Factories;
using CRUD.Domain.Items.Repositories;
using PlaygroundShared.Application.CQRS;

namespace CRUD.Application.Items.Commands.Handlers;

public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand>
{
    private readonly IItemRepository _itemRepository;
    private readonly IItemFactory _itemFactory;

    public CreateItemCommandHandler(IItemRepository itemRepository, IItemFactory itemFactory)
    {
        _itemRepository = itemRepository;
        _itemFactory = itemFactory;
    }
    
    public async Task HandleAsync(CreateItemCommand command)
    {
        var item = await _itemRepository.GetAsync(command.Id);
        if (item != null)
        {
            throw new DuplicatedException("item already exists");
        }
        
        item = _itemFactory.Create(new ItemDataStructure(command.Id, command.Name, command.Description, command.ExpirationDate));

        await _itemRepository.PersistAsync(item);
    }
}