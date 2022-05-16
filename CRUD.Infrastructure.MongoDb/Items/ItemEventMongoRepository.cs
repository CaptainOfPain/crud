using CRUD.Infrastructure.Persistence.Items;
using MongoDB.Driver;
using PlaygroundShared.Configurations;
using PlaygroundShared.Infrastructure.MongoDb.Repositories;

namespace CRUD.Infrastructure.MongoDb.Items;

public class ItemEventMongoRepository : GenericMongoEventRepository<ItemEventEntity>
{
    public ItemEventMongoRepository(IMongoClient mongoClient, IMongoDbConfiguration mongoDbConfiguration) : base(mongoClient, mongoDbConfiguration)
    {
    }
}