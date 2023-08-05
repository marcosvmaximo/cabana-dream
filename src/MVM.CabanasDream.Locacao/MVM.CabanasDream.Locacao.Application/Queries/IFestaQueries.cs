using System;
using MVM.CabanasDream.Locacao.Application.Queries.Dtos;

namespace MVM.CabanasDream.Locacao.Application.Queries;

public interface IFestaQueries
{
    Task<IEnumerable<ArtigoFestaDto>> ObterItemDeFestaPorTema(Guid temaId);
    Task<IEnumerable<FestaDto>> ObterFestasPorCliente(Guid clienteId);
    Task<FestaDto> ObterFesta(Guid festaId);
    Task<IEnumerable<ArtigoFestaDto>> ObterTodosArtigosDeFestas(Guid temaId);
}

