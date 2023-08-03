using MVM.CabanasDream.BussinesLogic.Models;
using MVM.CabanasDream.Core.Domain.Interfaces.Repositories;

namespace MVM.CabanasDream.BussinesLogic.Repositories;

public interface ITemaRepository : IRepository<Tema>
{
    Task<IEnumerable<Tema>> ObterTodosTemas();
    Task<Tema> ObterTemaPorId(Guid id);
    Task AdicionarTema(Tema tema);
    Task AtualizarTema(Tema tema);
    Task<IEnumerable<Item>> ObterItensDeTema(Guid idTema);
}

