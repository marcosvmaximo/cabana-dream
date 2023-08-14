using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents.FestaContext.Enum;
using MVM.CabanasDream.Locacao.Domain.Entities;

namespace MVM.CabanasDream.Locacao.Domain.Services.Interfaces;

public interface ILocacaoService
{
    Task LocarFesta(Guid clienteId, Guid temaId, int quantidadeParticipantes, DateTime dataRealizacao,
        List<ArtigoFesta> itemDeFestas = null);
    Task<Festa> ConfirmarFesta(Guid festaId);
    Task<Festa> ConfirmarPagamentoFesta(Guid festaId);
    Task<Festa> CancelarFesta(Guid festaId, DateTime dataFinalizacao, EMotivoCancelamento motivo);
    Task<Festa> CompletarFesta(Guid festaId, DateTime dataFinalizacao);
}