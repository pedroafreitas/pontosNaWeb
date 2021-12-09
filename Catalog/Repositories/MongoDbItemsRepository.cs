using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository
    {
        //All our documents will be in collections and the db will have a lot of collections
        private const string databasename = "catalog";
        private const string collectionName = "items";

        //this is used to filter the items that we want to use in mongdb
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;
        //We want to store mongo's collection
        private readonly IMongoCollection<Item> itemsCollection;


        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            //This will get us a reference to the db
            IMongoDatabase database = mongoClient.GetDatabase(databasename); 
            itemsCollection = database.GetCollection<Item>(collectionName);
        }
        
        public async Task CreateItemAsync(Item item)
        {
            await itemsCollection.InsertOneAsync(item);
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            await itemsCollection.DeleteOneAsync(filter);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return await itemsCollection.Find(filter).SingleOrDefaultAsync();

        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await itemsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            await itemsCollection.ReplaceOneAsync(filter, item);
        }
    }
}