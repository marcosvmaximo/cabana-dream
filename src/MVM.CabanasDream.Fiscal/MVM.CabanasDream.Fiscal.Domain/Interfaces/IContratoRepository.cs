using System;
using MVM.CabanasDream.Core.Data.Interfaces;
using MVM.CabanasDream.Core.Domain.Interfaces.Repositories;
using MVM.CabanasDream.Fiscal.Domain.Entities;

namespace MVM.CabanasDream.Fiscal.Domain.Interfaces;

public interface IContratoRepository : IRepository<Contrato>
{
    Task<Cliente> ObterClientePorId(Guid clienteId);
    Task<Festa> ObterFestaPorId(Guid festaId);
    Task<IEnumerable<Festa>> ObterFestasCanceladasPorCliente(Guid clienteId);
    Task SalvarContrato(Contrato contrato);
}

