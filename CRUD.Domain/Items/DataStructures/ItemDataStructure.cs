using PlaygroundShared.Domain.Domain;

namespace CRUD.Domain.Items.DataStructures;

public class ItemDataStructure
{
    public AggregateId Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime? ExpirationDate { get; }

    public ItemDataStructure(AggregateId id, string name, string description, DateTime? expirationDate)
    {
        Id = id;
        Name = name;
        Description = description;
        ExpirationDate = expirationDate; 
    }
}