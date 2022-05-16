using PlaygroundShared.Infrastructure.MongoDb.Attribute;
using PlaygroundShared.Infrastructure.MongoDb.Entities;

namespace CRUD.Infrastructure.Persistence.Items;


[MongoCollection("Items")]
public class ItemEntity : BaseMongoEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public bool IsArchived { get; set; }
}