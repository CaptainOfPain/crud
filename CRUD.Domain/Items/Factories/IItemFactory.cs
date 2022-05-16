using CRUD.Domain.Items.DataStructures;
using CRUD.Domain.Items.Models;

namespace CRUD.Domain.Items.Factories;

public interface IItemFactory
{
    Item Create(ItemDataStructure dataStructure);
}