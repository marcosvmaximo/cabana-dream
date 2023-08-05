using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Results;
using MVM.CabanasDream.Fiscal.Application.Commands;
using MVM.CabanasDream.Fiscal.Domain;
using MVM.CabanasDream.Fiscal.Domain.Entities;
using MVM.CabanasDream.Fiscal.Domain.Interfaces;

namespace MVM.CabanasDream.Locacao.Application.Commands.Handlers;

public class CriarContratoCommandHandler : Handler<CriarContratoCommand>
{
    private readonly IContratoRepository _repository;

    public CriarContratoCommandHandler(IContratoRepository repository)
    {
        _repository = repository;
    }

    //public override async Task<BaseResult> Handle(CriarContratoCommand command, CancellationToken cancellationToken)
    //{
    //    var cliente = ObterCliente(command.ClienteId);
    //    var festa = ObterFesta(command.FestaId);

    //    var dataDevolucao = festa.DataRealizacao.AddDays(2);
    //    var contrato = new ContratoLocacao(cliente, festa, dataDevolucao);

    //    festa.AdicionarContrato(contrato);
    //    contrato.AdicionarEvento(new EnviarEmailEvent(festa.Id, true));

    //    await _repository.UnityOfWork.Commit();
    //    return BaseResult.OkResult(contrato);
    //}


    public override async Task<BaseResult> Handle(CriarContratoCommand command, CancellationToken cancellationToken)
    {
        var cliente = ObterCliente(command.ClienteId);
        var festa = ObterFesta(command.FestaId);

        var contrato = new Contrato(cliente, festa, command.DataDevolucao);

        await _repository.SalvarContrato(contrato);
        await _repository.UnityOfWork.Commit();

        return BaseResult.OkResult(contrato);
    }

    private Festa? ObterFesta(Guid festaId)
    {
        return _repository.ObterFestaPorId(festaId).Result ?? throw new DomainException("Festa não encontrado");
    }

    private Cliente? ObterCliente(Guid clienteId)
    {
        return _repository.ObterClientePorId(clienteId).Result ?? throw new DomainException("Cliente não encontrado");
    }
}

