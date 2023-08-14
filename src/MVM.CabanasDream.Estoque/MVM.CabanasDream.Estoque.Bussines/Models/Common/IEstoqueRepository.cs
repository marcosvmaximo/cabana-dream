using MVM.CabanasDream.Core.Domain.Models;

namespace MVM.CabanasDream.Estoque.API.Models;

public interface IEstoqueRepository : IRepository<Tema>
{
    Task<Tema> ObterTemaPorId(Guid temaId);
    Task<ArtigoFesta> ObterArtigoFestaPorId(Guid artigoId);
    Task AtualizarTema(Tema tema);
    Task AtualizarArtigoFesta(ArtigoFesta artigo);
}

