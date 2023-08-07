using System;
namespace MVM.CabanasDream.Fiscal.API.Services.Interfaces;

public interface IContratoService
{
    Task CriarContrato(Guid festaId, Guid clienteId, DateTime dataDevolucao);
    Task FinalizarContrato();
    Task QuebrarContrato();
}

