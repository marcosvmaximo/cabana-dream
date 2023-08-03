using System;
using AutoMapper;
using MVM.CabanasDream.BussinesLogic.Dtos.Requests;
using MVM.CabanasDream.BussinesLogic.Models;

namespace MVM.CabanasDream.BussinesLogic.Mapping;

public class TemaProfile : Profile
{
    public TemaProfile()
    {
        CreateMap<Tema, TemaDto>();

        CreateMap<TemaDto, Tema>()
            .ConstructUsing(x => new Tema(x.Nome, x.Imagem));
    }
}