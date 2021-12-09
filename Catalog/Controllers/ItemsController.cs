using Microsoft.AspNetCore.Mvc;
using Catalog.Entities;
using System.Collections.Generic;
using System;
using Catalog.Repositories;
using System.Linq;
using Catalog.Dtos;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        // GET/items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItemsAsync().Select(item => item.AsDto());

            return items;
        }

        // GET/items/id
        [HttpGet("{id}")] //Here we specify how we are gonna create another piece of this route
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItemAsync(id);

            if(item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        // POST/items
        [HttpPost]  //adding route
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItemAsync(item);


            //The convention here is to return the item that has been created
            //and also return a header that specifies where you can get the info
            //about the item created.
                                    //Param 1: "What is action that reflects the route 
                                    //to get info about the item? GetItem."
                                    //Param 2: Where is the route data? Id.
                                    //Param 3: item is returned as dto.
            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            
            //with: getting a copy of existingItem with only the new atributes modified
            Item updatedItem = existingItem with {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repository.UpdateItemAsync(updatedItem);
            
            return NoContent();
        }

        // DELETE/items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            	var existingItem = repository.GetItemAsync(id);

                if(existingItem is null)
                {
                    return NotFound();
                }

                repository.DeleteItemAsync(id);
                
                return NoContent();
        }
    }
}