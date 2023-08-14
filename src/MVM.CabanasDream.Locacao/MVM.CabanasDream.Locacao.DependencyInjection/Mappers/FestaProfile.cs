using System;
using AutoMapper;
using MVM.CabanasDream.API.Models;
using MVM.CabanasDream.Locacao.Application.Commands;

namespace MVM.CabanasDream.API.Setup.Mappers;

public class FestaProfile : Profile
{
    public FestaProfile()
    {
        CreateMap<CriarFestaRequest, CriarFestaCommand>();
    }
}

