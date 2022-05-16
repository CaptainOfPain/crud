using CRUD.Domain.Items.Events;
using PlaygroundShared.Domain.Domain;
using PlaygroundShared.Domain.DomainEvents;
using PlaygroundShared.Domain.Exceptions;

namespace CRUD.Domain.Items.Models;

public class Item : BaseAggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime? ExpirationDate { get; private set; }
    public bool IsArchived { get; private set; }

    internal Item(AggregateId id, IDomainEventsManager domainEventsManager, string name, string description, DateTime? expirationDate) : base(id, domainEventsManager)
    {
        AssignData(name, description, expirationDate);
        DomainEvent(ItemCreatedEvent.Create(this));
    }

    private Item()
    {
        
    }

    public void Update(string name, string description, DateTime? expirationDate)
    {
        AssignData(name, description, expirationDate);
        DomainEvent(ItemUpdatedEvent.Create(this));
    }

    public void MarkAsArchived()
    {
        IsArchived = true;
        DomainEvent(ItemDeletedEvent.Create(this));
    }

    internal new void SetDependencies(IDomainEventsManager domainEventsManager)
    {
        base.SetDependencies(domainEventsManager);
    }

    private void AssignData(string name, string description, DateTime? expirationDate)
    {   
        SetName(name);
        SetDescription(description);
        SetExpirationDate(expirationDate);
    }

    private void SetExpirationDate(DateTime? expirationDate)
    {
        ExpirationDate = expirationDate;
    }

    private void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new BusinessLogicException("Description cannot be null");
        }
        Description = description;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new BusinessLogicException("Name cannot be null");
        }
        Name = name;
    }
}