using System;
namespace MVM.CabanasDream.Fiscal.Domain.Interfaces;

public interface IContratoService
{
    Task CriarContrato(Guid festaId, Guid clienteId, DateTime dataDevolucao);
}

