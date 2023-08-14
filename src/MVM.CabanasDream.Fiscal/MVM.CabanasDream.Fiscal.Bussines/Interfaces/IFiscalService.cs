using System;
using MVM.CabanasDream.Fiscal.API.Models.Dto;

namespace MVM.CabanasDream.Fiscal.API.Interfaces;

public interface IFiscalService
{
    Task CriarContrato(Guid festaId, Guid clienteId, DateTime dataDevolucao);
    Task ConfimarContrato(Guid contratoId);
    Task FinalizarContrato();
    Task QuebrarContrato();
    Task EnviarContrato(ModeloContrato modeloContrato);
}

