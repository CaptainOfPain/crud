using CRUD.Domain.Items.Models;
using PlaygroundShared.Domain.Domain;

namespace CRUD.Domain.Items.Repositories;

public interface IItemRepository : IAggregateRepository<Item>
{
    
}