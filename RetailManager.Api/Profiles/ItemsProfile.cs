using AutoMapper;
using RetailManager.Api.Models.Domain;
using RetailManager.Api.Models.DTO;

namespace RetailManager.Api.Profiles;

public class ItemsProfile : Profile
{
    public ItemsProfile()
    {
        CreateMap<Item, ItemDto>().ReverseMap();
        CreateMap<Item, AddItemRequest>().ReverseMap();
        CreateMap<Item, UpdateItemRequest>().ReverseMap();
    }
    
}