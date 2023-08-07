using System;
using MediatR;
using MVM.CabanasDream.Core.Domain.DomainEvents.Common;
using MVM.CabanasDream.Core.Domain.DomainEvents.Handlers;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.Domain.Results;
using MVM.CabanasDream.Locacao.Domain.Events;
using MVM.CabanasDream.Locacao.Domain.Repositories;

namespace MVM.CabanasDream.Locacao.Application.Events.Handlers;

public class TemaDisponivelEventHandler : INotificationHandler<TemaDisponivelEvent>
{
    private readonly IFestaRepository _repository;

    public TemaDisponivelEventHandler(IFestaRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(TemaDisponivelEvent message, CancellationToken cancellationToken)
    {
        var tema = await _repository.ObterTemaPorId(message.TemaId);

        if (tema == null)
            throw new DomainException("Tema informado inválido.");

        // Chamar serviço de email enviando para todos clientes que o tema voltou.
    }
}

