using System;
using MVM.CabanasDream.Core.Data.Interfaces;
using MVM.CabanasDream.Estoque.API.Data.Contexts;
using MVM.CabanasDream.Estoque.API.Models;

namespace MVM.CabanasDream.Estoque.API.Data.Repositories;

public class EstoqueRepository : IEstoqueRepository
{
    private readonly EstoqueContext _context;

    public EstoqueRepository(EstoqueContext context)
    {
        _context = context;
    }

    public IUnityOfWork UnityOfWork => throw new NotImplementedException();

    public Task AtualizarArtigoFesta(ArtigoFesta artigo)
    {
        throw new NotImplementedException();
    }

    public Task AtualizarTema(Tema tema)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<ArtigoFesta> ObterArtigoFestaPorId(Guid artigoId)
    {
        throw new NotImplementedException();
    }

    public Task<Tema> ObterTemaPorId(Guid temaId)
    {
        throw new NotImplementedException();
    }
}

