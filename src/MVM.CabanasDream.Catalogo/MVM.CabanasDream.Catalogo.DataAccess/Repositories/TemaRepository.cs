using System;
using Microsoft.EntityFrameworkCore;
using MVM.CabanasDream.BussinesLogic.Models;
using MVM.CabanasDream.BussinesLogic.Repositories;
using MVM.CabanasDream.Core.Data.Interfaces;
using MVM.CabanasDream.DataAccess.Context;

namespace MVM.CabanasDream.DataAccess.Repositories;

public class TemaRepository : ITemaRepository
{
    private readonly CatalogoContext _context;

    public TemaRepository(CatalogoContext context)
    {
        _context = context;
    }

    public IUnityOfWork UnityOfWork => _context;

    public async Task AdicionarTema(Tema tema)
    {
        await _context.Temas.AddAsync(tema);
    }

    public async Task AtualizarTema(Tema tema)
    {
        _context.Temas.Update(tema);
    }

    public async Task<Tema> ObterTemaPorId(Guid id)
    {
        return await _context.Temas.Include(x => x.Itens).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Tema>> ObterTodosTemas()
    {
        return await _context.Temas.Include(x => x.Itens).ToListAsync();
    }

    public async Task<IEnumerable<Item>> ObterItensDeTema(Guid idTema)
    {
        return await _context.Items.Where(x => x.TemaId == idTema).ToListAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

