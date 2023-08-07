﻿using MVM.CabanasDream.Core.Domain.Interfaces.Repositories;
using MVM.CabanasDream.Fiscal.API.Models;
using MVM.CabanasDream.Fiscal.API.Models.Entities;

namespace MVM.CabanasDream.Fiscal.API.Services.Interfaces;

public interface IContratoRepository : IRepository<Contrato>
{
    Task<Cliente> ObterClientePorId(Guid clienteId);
    Task<Festa> ObterFestaPorId(Guid festaId);
    Task<IEnumerable<Festa>> ObterFestasCanceladasPorCliente(Guid clienteId);
    Task SalvarContrato(Contrato contrato);
}

