using System;
using Microsoft.EntityFrameworkCore;
using MVM.CabanasDream.Core.Data.Interfaces;
using MVM.CabanasDream.Locacao.Data.Context;
using MVM.CabanasDream.Locacao.Domain;
using MVM.CabanasDream.Locacao.Domain.Entities;
using MVM.CabanasDream.Locacao.Domain.Repositories;

namespace MVM.CabanasDream.Locacao.Data.Repositories;

public class FestaRepository : IFestaRepository
{
    private readonly FestaContext _context;

    public FestaRepository(FestaContext context)
    {
        _context = context;
    }

    public IUnityOfWork UnityOfWork => _context;

    public async Task AdicionarFesta(Festa festa)
    {
        await _context.Festas.AddAsync(festa);
    }

    public async Task AtualizarFesta(Festa festa)
    {
        _context.Festas.Update(festa);
    }

    public async Task<Cliente?> ObterClientePorId(Guid clienteId)
    {
        return await _context.Clientes.AsTracking().FirstOrDefaultAsync(x => x.Id == clienteId);
    }

    public async Task<Festa?> ObterFestaPorId(Guid festaId)
    {
        return await _context.Festas.FirstOrDefaultAsync(x => x.Id == festaId);
    }

    public async Task<Tema?> ObterTemaPorId(Guid temaId)
    {
        return await _context.Temas.FirstOrDefaultAsync(x => x.Id == temaId);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<Festa?> ObterFestasPendentesPorCliente(Guid clienteId)
    {
        return await _context.Festas.FirstOrDefaultAsync(x => x.ClienteId == clienteId);
    }
}

