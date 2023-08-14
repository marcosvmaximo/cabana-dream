using MVM.CabanasDream.Core.Domain.Models;
using MVM.CabanasDream.Locacao.Domain.Entities;

namespace MVM.CabanasDream.Locacao.Domain.Repositories;

public interface IFestaRepository : IRepository<Festa>
{
    Task AdicionarFesta(Festa festa);
    Task AtualizarFesta(Festa festa);
    Task<Cliente?> ObterClientePorId(Guid clienteId);
    Task<IEnumerable<Festa>> ObterFestasPorCliente(Guid clienteId);
    Task<Festa?> ObterFestaPorId(Guid festaId);
    Task<Tema?> ObterTemaPorId(Guid temaId);
    Task<IEnumerable<ArtigoFesta?>> ObterTodosArtigosDeFesta();
}