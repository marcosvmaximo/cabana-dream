using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Fiscal.API.Models;
using MVM.CabanasDream.Fiscal.API.Models.Entities;
using MVM.CabanasDream.Fiscal.API.Services.Interfaces;

namespace MVM.CabanasDream.Fiscal.API.Services;

public class ContratoService : IContratoService
{
    private readonly IContratoRepository _repository;

    public ContratoService(IContratoRepository repository)
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

    private Festa ObterFesta(Guid festaId)
    {
        return _repository.ObterFestaPorId(festaId).Result ?? throw new DomainException("Festa não encontrado");
    }

    private Cliente ObterCliente(Guid clienteId)
    {
        return _repository.ObterClientePorId(clienteId).Result ?? throw new DomainException("Cliente não encontrado");
    }
}

