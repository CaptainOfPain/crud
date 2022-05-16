using PlaygroundShared.Application.CQRS;
using PlaygroundShared.Domain.Domain;

namespace CRUD.Application.Items.Commands;

public class CreateItemCommand : ICommand
{
    public AggregateId Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime? ExpirationDate { get; }

    public CreateItemCommand(string name, string description, DateTime? expirationDate)
    {
        Id = AggregateId.Generate();
        Name = name;
        Description = description;
        ExpirationDate = expirationDate;
    }
}