using MVM.CabanasDream.BussinesLogic.Dtos.Requests;
using MVM.CabanasDream.BussinesLogic.Models;

namespace MVM.CabanasDream.BussinesLogic.Services.Interfaces;

public interface ICatalogoService : IDisposable
{
    Task<IEnumerable<Tema>> ObterTodosTemas();
    Task<Tema> ObterTemaPorId(Guid id);
    Task<Tema> AdicionarTema(TemaDto request);
    Task<Tema> AdicionarItemAoTema(Guid id, ItemDto request);
}

