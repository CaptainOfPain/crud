using CRUD.Domain.Items.Models;

namespace CRUD.Application.Items.DTOs;

public class ItemDto
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime? ExpirationDate { get; }

    public ItemDto(Guid id, string name, string description, DateTime? expirationDate)
    {
        Id = id;
        Name = name;
        Description = description;
        ExpirationDate = expirationDate;
    }

    public static ItemDto From(Item item)
        => new(item.Id.Id, item.Name, item.Description, item.ExpirationDate);
}