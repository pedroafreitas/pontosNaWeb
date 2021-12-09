using Microsoft.AspNetCore.Mvc;
using Catalog.Entities;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
                        //first go ahead and do this and then the select
            var items = (await repository.GetItemsAsync())
                        .Select(item => item.AsDto());

            return items;
        }

        // GET/items/id
        [HttpGet("{id}")] //Here we specify how we are gonna create another piece of this route
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item = await repository.GetItemAsync(id);

            if(item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        // POST/items
        [HttpPost]  //adding route
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
        {
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await repository.CreateItemAsync(item);


            //The convention here is to return the item that has been created
            //and also return a header that specifies where you can get the info
            //about the item created.
                                    //Param 1: "What is action that reflects the route 
                                    //to get info about the item? GetItem."
                                    //Param 2: Where is the route data? Id.
                                    //Param 3: item is returned as dto.
            return CreatedAtAction(nameof(GetItemAsync), new {id = item.Id}, item.AsDto());
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            
            //with: getting a copy of existingItem with only the new atributes modified
            Item updatedItem = existingItem with {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            await repository.UpdateItemAsync(updatedItem);
            
            return NoContent();
        }

        // DELETE/items/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            	var existingItem = repository.GetItemAsync(id);

                if(existingItem is null)
                {
                    return NotFound(); 
                }

                await repository.DeleteItemAsync(id);
                
                return NoContent();
        }
    }
}