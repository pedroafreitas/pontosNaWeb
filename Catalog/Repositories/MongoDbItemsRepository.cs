using System;
using System.Collections.Generic;
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
        
        public void CreateItemAsync(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public void DeleteItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            itemsCollection.DeleteOne(filter);
        }

        public Item GetItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return itemsCollection.Find(filter).SingleOrDefault();

        }

        public IEnumerable<Item> GetItemsAsync()
        {
            return itemsCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateItemAsync(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            itemsCollection.ReplaceOne(filter, item);
        }
    }
}