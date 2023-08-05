using MVM.CabanasDream.Locacao.Domain.Entities;

namespace MVM.CabanasDream.Locacao.Domain.Services.Interfaces;

public interface ILocacaoService
{
    Task LocarFesta(Guid clienteId, Guid temaId, int quantidadeParticipantes, DateTime dataRealizacao,
        List<ArtigoFesta> itemDeFestas = null);
    Task<Festa> FecharContratoFesta(Guid festaId);
    Task<Festa> ConcluirFesta(Guid festaId);
    Task<Festa> CancelarFesta(Guid festaId);
}