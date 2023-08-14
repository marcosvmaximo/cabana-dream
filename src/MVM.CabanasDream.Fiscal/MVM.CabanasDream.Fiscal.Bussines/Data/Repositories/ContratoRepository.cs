using MVM.CabanasDream.Core.Data.Interfaces;
using MVM.CabanasDream.Fiscal.API.Data.Context;
using MVM.CabanasDream.Fiscal.API.Interfaces;
using MVM.CabanasDream.Fiscal.API.Models;
using MVM.CabanasDream.Fiscal.API.Models.Entities;

namespace MVM.CabanasDream.Fiscal.API.Data.Repositories;

public class ContratoRepository : IContratoRepository
{
    private readonly FiscalContext _context;

    public ContratoRepository(FiscalContext context)
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

    public Task AtualizarContrato(Contrato contrato)
    {
        throw new NotImplementedException();
    }
}

