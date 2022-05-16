using PlaygroundShared.Application.CQRS;
using PlaygroundShared.Domain.Domain;

namespace CRUD.Application.Items.Commands;

public class DeleteItemCommand : ICommand
{
    public AggregateId Id { get; }

    public DeleteItemCommand(AggregateId id)
    {
        Id = id;
    }
}