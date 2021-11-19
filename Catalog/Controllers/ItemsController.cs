using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemoryItemsRepository repository;

        public ItemsController()
        {
            repository = new InMemoryItemsRepository();
        }

        // GET/items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }

        // GET/items/id
        [HttpGet("{id}")] //Here we specify how we are gonna create another piece of this route
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if(item is null)
            {
                return NotFound();
            }

            return item;
        }
    }
}