using PlaygroundShared.Infrastructure.MongoDb.Attribute;
using PlaygroundShared.Infrastructure.MongoDb.Entities;

namespace CRUD.Infrastructure.Persistence.Items;

[MongoCollection("Items")]
public class ItemEventEntity : BaseMongoEventEntity
{
    
}