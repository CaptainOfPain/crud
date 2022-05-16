using PlaygroundShared.Application.CQRS;
using PlaygroundShared.Domain.Domain;

namespace CRUD.Application.Items.Commands;

public class UpdateItemCommand : ICommand
{
    public AggregateId Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime? ExpirationDate { get; }

    public UpdateItemCommand(AggregateId id, string name, string description, DateTime? expirationDate)
    {
        Id = id;
        Name = name;
        Description = description;
        ExpirationDate = expirationDate;
    }
}