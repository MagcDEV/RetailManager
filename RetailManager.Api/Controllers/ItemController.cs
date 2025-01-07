using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RetailManager.Api.Models.Domain;
using RetailManager.Api.Models.DTO;
using RetailManager.Api.Repositories;

namespace RetailManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController(IItemRepository itemRepository, IMapper mapper) : Controller
{
    
    [HttpGet]
    public async Task<IActionResult> GetAllItems()
    {
        var items = await itemRepository.GetAllItemsAsync();
        
        if (!items.Any())
        {
            return NotFound();
        }
        
        var itemsDto = mapper.Map<IEnumerable<ItemDto>>(items);
        
        return Ok(itemsDto);
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    [ActionName("GetItemByIdAsync")]
    public async Task<IActionResult> GetItem(Guid id)
    {
        var item = await itemRepository.GetItemByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        var itemDto = mapper.Map<ItemDto>(item);
        return Ok(itemDto);
    }
    
    [HttpGet]
    [Route("{barcode}")]
    [ActionName("GetItemByBarcodeAsync")]
    public async Task<IActionResult> GetItemByBarcode(string barcode)
    {
        var item = await itemRepository.GetItemByBarcodeAsync(barcode);
        if (item == null)
        {
            return NotFound();
        }
        var itemDto = mapper.Map<ItemDto>(item);
        return Ok(itemDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddItemAsync(AddItemRequest addItemRequest)
    {
        var item = mapper.Map<Item>(addItemRequest);
        
        var createdItem = await itemRepository.CreateItemAsync(item);
        
        var itemDto = mapper.Map<ItemDto>(createdItem);
        return CreatedAtAction("GetItemByIdAsync", new { id = item.Id }, itemDto);
    }
    
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateItemAsync([FromRoute] Guid id, [FromBody] UpdateItemRequest updateItemRequest)
    {
        var item = await itemRepository.GetItemByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        
        var updatedItem = mapper.Map(updateItemRequest, item);
        
        var itemDto = mapper.Map<ItemDto>(updatedItem);
        return Ok(itemDto);
    }
    
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteItemAsync(Guid id)
    {
        var item = await itemRepository.GetItemByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        
        await itemRepository.DeleteItemAsync(item.Id);
        
        var itemDto = mapper.Map<ItemDto>(item);
        
        return Ok(itemDto);
    }
    
    
}