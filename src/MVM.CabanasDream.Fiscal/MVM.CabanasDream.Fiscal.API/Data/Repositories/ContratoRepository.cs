using System;
using MVM.CabanasDream.Core.Data.Interfaces;
using MVM.CabanasDream.Fiscal.API.Data.Context;
using MVM.CabanasDream.Fiscal.API.Models;
using MVM.CabanasDream.Fiscal.API.Models.Entities;
using MVM.CabanasDream.Fiscal.API.Services.Interfaces;

namespace MVM.CabanasDream.Fiscal.API.Data.Repositories;

public class ContratoRepository : IContratoRepository
{
    private readonly ContratoContext _context;

    public ContratoRepository(ContratoContext context)
    {
        _context = context;
    }

    public IUnityOfWork UnityOfWork => _context;

    public Task<Cliente> ObterClientePorId(Guid clienteId)
    {
        throw new NotImplementedException();
    }

    public Task<Festa> ObterFestaPorId(Guid festaId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Festa>> ObterFestasCanceladasPorCliente(Guid clienteId)
    {
        throw new NotImplementedException();
    }

    public Task SalvarContrato(Contrato contrato)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

