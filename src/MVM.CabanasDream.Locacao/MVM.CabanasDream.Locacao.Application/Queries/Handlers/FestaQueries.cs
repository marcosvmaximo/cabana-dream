using System;
using MVM.CabanasDream.Locacao.Application.Queries.Dtos;
using MVM.CabanasDream.Locacao.Application.Queries.Interfaces;
using MVM.CabanasDream.Locacao.Domain.Repositories;

namespace MVM.CabanasDream.Locacao.Application.Queries.Handlers;

public class FestaQueries : IFestaQueries
{
    private readonly IFestaRepository _repository;

    public FestaQueries(IFestaRepository repository)
    {
        _repository = repository;
    }

    public Task<ContratoViewModel> ObterContratoPorCliente(Guid clienteId)
    {
        throw new NotImplementedException();
    }

    public Task<List<ItemDeFestaViewModel>> ObterItemDeFestaPorTema(Guid temaId)
    {
        throw new NotImplementedException();
    }

    public Task<List<TemaViewModel>> ObterTemas()
    {
        throw new NotImplementedException();
    }
}

