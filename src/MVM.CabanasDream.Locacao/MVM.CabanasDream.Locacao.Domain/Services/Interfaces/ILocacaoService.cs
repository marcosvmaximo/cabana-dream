using MVM.CabanasDream.Locacao.Domain.Entities;

namespace MVM.CabanasDream.Locacao.Domain.Services.Interfaces;

public interface ILocacaoService
{
    Task LocarFesta(Guid clienteId, Guid temaId, int quantidadeParticipantes, DateTime dataRealizacao,
        List<ArtigoFesta> itemDeFestas = null);
    Task<Festa> FecharContratoFesta(Guid festaId);
    Task<Festa> FinalizarFesta(Guid festaId, DateTime dataFinalizacao);
    Task<Festa> CancelarFesta(Guid festaId, DateTime dataFinalizacao, string motivo);
}