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
        var cliente = await _context.Clientes.AsTracking().FirstOrDefaultAsync(x => x.Id == clienteId);

        await _context.Entry(cliente)
            .Collection(f => f.Festas)
            .LoadAsync();

        return cliente;
    }

    public async Task<Festa?> ObterFestaPorId(Guid festaId)
    {
        var festa = await _context.Festas.FirstOrDefaultAsync(x => x.Id == festaId);

        await _context.Entry(festa)
            .Reference(f => f.Tema)
            .LoadAsync();

        await _context.Entry(festa)
            .Collection(f => f.ArtigosDeFesta)
            .LoadAsync();

        await _context.Entry(festa)
            .Reference(f => f.Cliente)
            .LoadAsync();

        return festa;
    }

    public async Task<Tema?> ObterTemaPorId(Guid temaId)
    {
        var tema = await _context.Temas.FirstOrDefaultAsync(x => x.Id == temaId);


        await _context.Entry(tema)
            .Collection(f => f.ArtigosDeFesta)
            .LoadAsync();

        await _context.Entry(tema)
            .Collection(f => f.Festas)
            .LoadAsync();

        return tema;
    }

    public async Task<Festa?> ObterFestasPendentesPorCliente(Guid clienteId)
    {
        var festa = await _context.Festas.FirstOrDefaultAsync(x => x.ClienteId == clienteId);

        await _context.Entry(festa)
            .Reference(f => f.Tema)
            .LoadAsync();

        await _context.Entry(festa)
            .Collection(f => f.ArtigosDeFesta)
            .LoadAsync();

        await _context.Entry(festa)
            .Reference(f => f.Cliente)
            .LoadAsync();

        return festa;
    }

    public async Task<IEnumerable<Festa?>> ObterFestasPorCliente(Guid clienteId)
    {
        var festas = _context.Festas
                        .Where(x => x.ClienteId == clienteId)
                        .ToList();

        foreach (var festa in festas)
        {
            await _context.Entry(festa)
                          .Reference(f => f.Tema)
                          .LoadAsync();

            await _context.Entry(festa)
                          .Reference(f => f.Cliente)
                          .LoadAsync();

            await _context.Entry(festa)
                          .Collection(f => f.ArtigosDeFesta)
                          .LoadAsync();
        }

        return festas;
    }

    public async Task<IEnumerable<ArtigoFesta?>> ObterTodosArtigosDeFesta()
    {
        return await _context.ArtigosDeFestas.AsNoTracking().ToListAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

