using System;
using Catalog.Entities;


namespace Catalog.Repositories
{
    public interface IInMemoryItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();

        void CreateItem(Item item);
    }
}