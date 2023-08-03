using System;
using MVM.CabanasDream.Locacao.Application.Queries.Dtos;

namespace MVM.CabanasDream.Locacao.Application.Queries.Interfaces;

public interface IFestaQueries
{
    Task<ContratoViewModel> ObterContratoPorCliente(Guid clienteId);
    Task<List<ItemDeFestaViewModel>> ObterItemDeFestaPorTema(Guid temaId);
    Task<List<TemaViewModel>> ObterTemas();
}

