using System;
using MVM.CabanasDream.Core.Data.Interfaces;
using MVM.CabanasDream.Fiscal.API.Models;
using MVM.CabanasDream.Fiscal.API.Models.Entities;
using MVM.CabanasDream.Fiscal.API.Services.Interfaces;

namespace MVM.CabanasDream.Fiscal.API.Data.Repositories;

public class ContratoRepository : IContratoRepository
{
    public ContratoRepository()
    {
    }

    public IUnityOfWork UnityOfWork => throw new NotImplementedException();

    public void Dispose()
    {
        throw new NotImplementedException();
    }

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
}

