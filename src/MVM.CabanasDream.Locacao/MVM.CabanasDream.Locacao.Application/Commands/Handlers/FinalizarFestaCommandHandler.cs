using System;
using MVM.CabanasDream.Core.Comunications.Messages;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers.Interfaces;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Results;
using MVM.CabanasDream.Locacao.Domain.Repositories;

namespace MVM.CabanasDream.Locacao.Application.Commands.Handlers;

public class FinalizarFestaCommandHandler : Handler<FinalizarFestaCommand>
{
    private readonly IMediatrHandler _mediator;
    private readonly IFestaRepository _repository;

    public FinalizarFestaCommandHandler(IFestaRepository repository, IMediatrHandler mediator)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public override async Task<BaseResult> Handle(FinalizarFestaCommand command, CancellationToken cancellationToken)
    {
        if (command.DataFinalizacao >= DateTime.Now)
        {
            throw new DomainException("Não é possível finalizar uma festa no futuro.");
        }

        var festa = await _repository.ObterFestaPorId(command.FestaId) ??
            throw new DomainException("Festa informada não existe.");

        festa!.FinalizarFesta(command.DataFinalizacao);

        await _repository.AtualizarFesta(festa);
        return BaseResult.OkResult(festa);
    }

    protected override bool ValidarComando(FinalizarFestaCommand command)
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

