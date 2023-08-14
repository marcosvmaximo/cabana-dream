using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Fiscal.API.Interfaces;
using MVM.CabanasDream.Fiscal.API.Models;
using MVM.CabanasDream.Fiscal.API.Models.Dto;
using MVM.CabanasDream.Fiscal.API.Models.Entities;

namespace MVM.CabanasDream.Fiscal.API.Services;

public class FiscalService : IFiscalService
{
    private readonly IContratoRepository _repository;

    public FiscalService(IContratoRepository repository)
    {
        _repository = repository;
    }

    public async Task CriarContrato(Guid festaId, Guid clienteId, DateTime dataDevolucao)
    {
        var festa = ObterFesta(festaId);
        var cliente = ObterCliente(clienteId);

        var contrato = new Contrato(cliente, festa, dataDevolucao);

        await _repository.SalvarContrato(contrato);
        await _repository.UnityOfWork.Commit();
    }

    public Task FinalizarContrato()
    {
        // Após a festa estar concluida
        throw new NotImplementedException();
    }

    public Task QuebrarContrato()
    {
        throw new NotImplementedException();
    }

    private Festa ObterFesta(Guid festaId)
    {
        return _repository.ObterFestaPorId(festaId).Result ?? throw new DomainException("Festa não encontrado");
    }

    private Cliente ObterCliente(Guid clienteId)
    {
        return _repository.ObterClientePorId(clienteId).Result ?? throw new DomainException("Cliente não encontrado");
    }

    public Task EnviarContrato(ModeloContrato modeloContrato)
    {
        throw new NotImplementedException();
    }

    public Task ConfimarContrato(Guid contratoId)
    {
        throw new NotImplementedException();
    }
}

