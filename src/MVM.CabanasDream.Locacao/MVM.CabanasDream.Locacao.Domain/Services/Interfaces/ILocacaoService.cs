using System;
using MVM.CabanasDream.Locacao.Domain.Entities;
using MVM.CabanasDream.Locacao.Domain.ValueObjects;

namespace MVM.CabanasDream.Locacao.Domain.Services.Interfaces;

public interface ILocacaoService
{
    Task LocarFesta(Guid clienteId, Guid temaId, int quantidadeParticipantes, DateTime dataRealizacao,
        List<ItemDeFesta> itemDeFestas = null);
    Task FecharFesta(Guid festaId);
    Task<decimal?> CancelarFesta(Guid festaId);
    Task<ContratoLocacao> MostrarTermosDoContrato(Guid festaId);
}