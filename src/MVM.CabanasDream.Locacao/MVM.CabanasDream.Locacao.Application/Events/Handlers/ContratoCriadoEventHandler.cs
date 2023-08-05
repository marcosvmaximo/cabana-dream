using System;
using MediatR;
using MVM.CabanasDream.Core.Domain.Exceptions;
using MVM.CabanasDream.Core.DomainObjects.Events.IntegrationEvents;
using MVM.CabanasDream.Locacao.Domain;
using MVM.CabanasDream.Locacao.Domain.Repositories;

namespace MVM.CabanasDream.Locacao.Application.Events.Handlers;

public class ContratoCriadoEventHandler : INotificationHandler<ContratoCriadoEvent>
{
    private readonly IFestaRepository _repository;

    public ContratoCriadoEventHandler(IFestaRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(ContratoCriadoEvent message, CancellationToken cancellationToken)
    {
        Festa festa = await _repository.ObterFestaPorId(message.FestaId) ?? throw new DomainException("Festa inserida é inválida");

        festa.ConfirmarFesta();

        await _repository.AtualizarFesta(festa);
    }
}

