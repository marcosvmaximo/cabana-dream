using System;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Results;
using MVM.CabanasDream.Locacao.Domain.Repositories;

namespace MVM.CabanasDream.Locacao.Application.Commands.Handlers;

public class CancelarFestaCommandHandler : Handler<CancelarFestaCommand>
{
    private readonly IMediatrHandler _mediator;
    private readonly IFestaRepository _repository;

    public CancelarFestaCommandHandler(IFestaRepository repository, IMediatrHandler mediator)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public override async Task<BaseResult> Handle(CancelarFestaCommand command, CancellationToken cancellationToken)
    {
        var festa = await _repository.ObterFestaPorId(command.FestaId) ??
            throw new DomainException("Festa informado não foi encontrada.");

        festa.CancelarFesta(command.DataFinalizacao, command.Motivo);

        await _repository.AtualizarFesta(festa);
        await _repository.UnityOfWork.Commit();

        return BaseResult.OkResult(festa);
    }

    protected override bool ValidarComando(CancelarFestaCommand command)
    {
        if (!command.EhValido())
        {
            foreach (var error in command.ValidationResult.Errors)
            {
                _mediator.PublicarNotificacao(new DomainNotification(
                    error.PropertyName, error.ErrorMessage));
            }
        }

        return command.EhValido();
    }
}

