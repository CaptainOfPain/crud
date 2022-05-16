using CRUD.Infrastructure.Persistence.Items;
using MongoDB.Driver;
using PlaygroundShared.Configurations;
using PlaygroundShared.Infrastructure.MongoDb.Repositories;

namespace CRUD.Infrastructure.MongoDb.Items;

public class ItemMongoRepository : GenericMongoRepository<ItemEntity>
{
    public ItemMongoRepository(IMongoClient mongoClient, IMongoDbConfiguration mongoDbConfiguration) : base(mongoClient, mongoDbConfiguration)
    {
    }
}