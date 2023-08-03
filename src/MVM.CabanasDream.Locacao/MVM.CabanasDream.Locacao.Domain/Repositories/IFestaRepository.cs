using MVM.CabanasDream.Core.Domain.Interfaces.Repositories;
using MVM.CabanasDream.Locacao.Domain.Entities;

namespace MVM.CabanasDream.Locacao.Domain.Repositories;

public interface IFestaRepository : IRepository<Festa>
{
    Task AdicionarFesta(Festa festa);
    Task AtualizarFesta(Festa festa);
    Task<Cliente?> ObterClientePorId(Guid clienteId);
    Task<Festa?> ObterFestaPorId(Guid festaId);
    Task<Festa?> ObterFestasPendentesPorCliente(Guid clienteId);
    Task<Tema?> ObterTemaPorId(Guid temaId);
}