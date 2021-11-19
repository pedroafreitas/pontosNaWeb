using System;
using Catalog.Entities;


namespace Catalog.Repositories
{
    public interface IInMemoryItemsRepository
    {
        IHostMetadata GetItem(Guid id);
        IEnumerable<Item> GetItems();
        
    }
}