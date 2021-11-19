using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;
using Catalog.Dtos;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IInMemoryItemsRepository repository;

        public ItemsController(IInMemoryItemsRepository repository)
        {
            this.repository = repository;
        }

        // GET/items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());

            return items;
        }

        // GET/items/id
        [HttpGet("{id}")] //Here we specify how we are gonna create another piece of this route
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if(item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }
    }
}