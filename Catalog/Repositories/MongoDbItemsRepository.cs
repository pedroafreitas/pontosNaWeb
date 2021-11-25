using Catalog.Entities;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository
    {
        //All our documents will be in collections and the db will have a lot of collections
        private const string databasename = "catalog";
        private const string collectionName = "items";
        //We want to store mongo's collection
        private readonly IMongoCollection<Item>? itemsCollection;


        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            //This will get us a reference to the db
            IMongoDatabase database = mongoClient.GetDatabase(databasename); 
            itemsCollection = database.GetCollection<Item>(collectionName);
        }
        
        public void CreateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}