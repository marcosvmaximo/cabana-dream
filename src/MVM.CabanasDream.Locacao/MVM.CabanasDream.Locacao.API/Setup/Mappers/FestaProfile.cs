using System;
using AutoMapper;
using MVM.CabanasDream.Locacao.API.Models;
using MVM.CabanasDream.Locacao.Application.Commands;

namespace MVM.CabanasDream.Locacao.API.Setup.Mappers;

public class FestaProfile : Profile
{
    public FestaProfile()
    {
        CreateMap<CriarFestaRequest, CriarFestaCommand>();
    }
}

