using System.Net.NetworkInformation;
using MVM.CabanasDream.Locacao.Application.Queries.Dtos;
using MVM.CabanasDream.Locacao.Domain;
using MVM.CabanasDream.Locacao.Domain.Entities;
using MVM.CabanasDream.Locacao.Domain.Repositories;

namespace MVM.CabanasDream.Locacao.Application.Queries;

public class FestaQueries : IFestaQueries
{
    private readonly IFestaRepository _repository;

    public FestaQueries(IFestaRepository repository)
    {
        _repository = repository;
    }

    public async Task<FestaDto> ObterFesta(Guid festaId)
    {
        var festa = await _repository.ObterFestaPorId(festaId);

        return new FestaDto()
        {
            ClienteId = festa.ClienteId,
            TemaId = festa.TemaId,
            QuantidadeParticipantes = festa.QuantidadeParticipantes,
            Status = festa.Status,
            DataRealizacao = festa.DataRealizacao,
            ContratoId = festa.ContratoId,
            ArtigosDeFesta = ArtigoFestaDto.Factory.Create(festa.ArtigosDeFesta)
        };
    }

    public async Task<IEnumerable<FestaDto>> ObterFestasPorCliente(Guid clienteId)
    {
        var festas = await _repository.ObterFestasPorCliente(clienteId);

        var festasDto = festas.Select(festa => new FestaDto()
        {
            ClienteId = festa.ClienteId,
            TemaId = festa.TemaId,
            QuantidadeParticipantes = festa.QuantidadeParticipantes,
            Status = festa.Status,
            DataRealizacao = festa.DataRealizacao,
            ContratoId = festa.ContratoId,
            ArtigosDeFesta = ArtigoFestaDto.Factory.Create(festa.ArtigosDeFesta)
        });

        return festasDto;
    }

    public async Task<IEnumerable<ArtigoFestaDto>> ObterItemDeFestaPorTema(Guid temaId)
    {
        var todosArtigos = await _repository.ObterTodosArtigosDeFesta();
        var artigos = todosArtigos.Where(x => x.TemaId == temaId);

        var artigosDto = artigos.Select(artigo => new ArtigoFestaDto()
        {
            Nome = artigo?.Nome,
            Valor = artigo.Valor,
            Quantidade = artigo.Quantidade
        });

        return artigosDto;
    }


    public async Task<IEnumerable<ArtigoFestaDto>> ObterTodosArtigosDeFestas(Guid temaId)
    {
        var todosArtigos = await _repository.ObterTodosArtigosDeFesta();
        var artigos = todosArtigos.Where(x => x.TemaId == temaId);

        var artigosDto = artigos.Select(artigo => new ArtigoFestaDto()
        {
            Nome = artigo?.Nome,
            Valor = artigo.Valor,
            Quantidade = artigo.Quantidade
        });

        return artigosDto;
    }
}

