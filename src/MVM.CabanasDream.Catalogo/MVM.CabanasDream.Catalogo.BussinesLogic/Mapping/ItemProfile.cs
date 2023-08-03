using AutoMapper;
using MVM.CabanasDream.BussinesLogic.Dtos.Requests;
using MVM.CabanasDream.BussinesLogic.Models;

namespace MVM.CabanasDream.BussinesLogic.Mapping;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Item, ItemDto>();
        CreateMap<ItemDto, Item>()
            .ConstructUsing(x => new Item(x.ObjetoFesta, x.Quantidade));
    }
}